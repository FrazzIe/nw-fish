using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using WindowsInput;
using WindowsInput.Native;
using System.Diagnostics;

namespace nw_fish
{
    public class Fisher
    {
        private bool working;
        private bool validated;
        private bool antiAfk;
        private bool freeLook;
        private bool stopWhenEncumbered;
        private bool equipBait;
        private CancellationTokenSource cancellationTokenSource;
        private Thread thread;
        private Screen targetDisplay;
        private DisplayArea targetArea;
        private DisplayArea repairArea;
        private DisplayArea encumberedArea;
        private DisplayArea baitArea;
        private DisplayArea equipBaitArea;
        private Dictionary<string, ImageTemplate> imageTemplates;
        private Dictionary<string, ColorTemplate> colorTemplates;        
        private InputSimulator inputSimulator; //Used for input
        private VirtualKeyCode freeLookKeybind;
        private VirtualKeyCode inventoryKeybind;
        private const int maxCastIdleTime = 5000;
        private const int maxReelIdleTime = 5000;
        private const int maxCastTime = 1980;
        private int castTime;
        private int afkTime;
        private int repairAfterRunCount;
        private int runsCount;
        private enum State
        {
            Idle = 0,
            Casting = 1,
            Reel = 2
        }
        private enum ReelAction
        {
            None = 0,
            In = 1,
            Wait = 2,
            Out = 3,
        }

        public bool Working { 
            get { return working; }
        }

        public bool AntiAFK
        {
            get { return antiAfk; }
            set { antiAfk = value; }
        }

        public bool FreeLook { 
            get { return freeLook; }
            set { freeLook = value; }
        }

        public bool StopWhenEncumbered
        {
            get { return stopWhenEncumbered; }
            set { stopWhenEncumbered = value; }
        }

        public bool EquipBait
        {
            get { return equipBait; }
            set { equipBait = value; }
        }

        public VirtualKeyCode FreeLookKeybind
        {
            get { return freeLookKeybind; }
            set { freeLookKeybind = value; }
        }

        public VirtualKeyCode InventoryKeybind
        {
            get { return inventoryKeybind; }
            set { inventoryKeybind = value; }
        }
        public int Runs
        {
            get { return runsCount; }
        }

        public Fisher() {
            working = false;
            validated = false;
            antiAfk = false;
            freeLook = true;
            stopWhenEncumbered = false;
            equipBait = false;
            targetDisplay = null;
            targetArea = null;
            repairArea = null;
            imageTemplates = new Dictionary<string, ImageTemplate>()
            {
                ["start"] = new ImageTemplate(),
                ["cast"] = new ImageTemplate(),
                ["hook"] = new ImageTemplate(),
                ["reel"] = new ImageTemplate()
            };
            colorTemplates = new Dictionary<string, ColorTemplate>()
            { 
                ["reel_start"] = new ColorTemplate(),
                ["reel_wait"] = new ColorTemplate(),
                ["reel_stop"] = new ColorTemplate(),
                ["encumbered"] = new ColorTemplate()
            };            
            inputSimulator = new InputSimulator(); //Used for input
            freeLookKeybind = VirtualKeyCode.LMENU;
            inventoryKeybind = VirtualKeyCode.TAB;
            castTime = maxCastTime;
            afkTime = 120000;
            repairAfterRunCount = 10;
            runsCount = 0;

            CreateThread();
        }

        private void CreateThread()
        {
            cancellationTokenSource = new CancellationTokenSource();
            thread = new Thread(() => Task(cancellationTokenSource.Token));
            thread.IsBackground = true;
        }

        private void Task(CancellationToken token)
        {
            State action = State.Idle;
            Random random = new Random();
            bool reeling = false;
            bool afkMove = false;
            bool freeLooking = false;
            bool baitEquipped = false;
            Stopwatch afkStopwatch = new Stopwatch();
            Stopwatch castStopwatch = new Stopwatch();
            Stopwatch reelStopwatch = new Stopwatch();

            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Stopping..");
                    CreateThread();
                    working = false;
                    return;
                }

                if (!validated)
                {                    
                    if (targetArea == null)
                    {
                        Error(new ErrorEventArgs { Message = "No target area has been set!" });
                        return;
                    }
                    if (repairArea == null)
                    {
                        Error(new ErrorEventArgs { Message = "No repair area has been set!" });
                        return;
                    }
                    if (!imageTemplates.Values.All((value) => value.Image != null))
                    {
                        Error(new ErrorEventArgs { Message = "Missing one or more image templates!" });
                        return;
                    }
                    if (!colorTemplates.Values.All((value) => value.Color != null))
                    {
                        Error(new ErrorEventArgs { Message = "Missing one or more colour templates!" });
                        return;
                    }

                    validated = true;

                    for (int i = 5; i > 0; i--)
                    {
                        Notify(new NotifyEventArgs() { Message = $"Starting in {i}..\r\n" });
                        Thread.Sleep(1000);
                    }
                }

                if (antiAfk && !afkMove)
                {
                    if (afkStopwatch.IsRunning && afkStopwatch.ElapsedMilliseconds > afkTime)
                    {
                        afkMove = true;
                        afkStopwatch.Reset();
                    }
                    else if (!afkStopwatch.IsRunning)
                        afkStopwatch.Start();
                }

                Image<Bgr, Byte> targetImage = targetArea.GetImage();

                switch (action)
                {
                    case State.Idle:
                        Image<Gray, float> idleImageMatch = targetImage.MatchTemplate(imageTemplates["start"].Image, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
                        TemplateResult idleImageBestMatch = GetBestMatchFromTemplate(idleImageMatch);

                        idleImageMatch.Dispose();
                        targetImage.Dispose();

                        if (idleImageBestMatch.value > imageTemplates["start"].Tolerance)
                        {
                            runsCount++;
                            RunChanged(new RunChangedEventArgs() { Count = runsCount });

                            if (freeLooking)
                            {
                                inputSimulator.Keyboard.KeyUp(freeLookKeybind).Sleep(150);
                                freeLooking = false;
                            }

                            if (stopWhenEncumbered)
                            {
                                Image<Bgr, Byte> encumberedTarget = encumberedArea.GetImage();

                                Notify(new NotifyEventArgs() { Message = "Checking if encumbered...\r\n" });

                                if (Encumbered(encumberedTarget))
                                {
                                    Notify(new NotifyEventArgs() { Message = "Stopping... (Reason: Encumbered)\r\n" });
                                    Error(new ErrorEventArgs());
                                    return;
                                }

                                encumberedTarget.Dispose();
                            }

                            if (runsCount % repairAfterRunCount == 0)
                            {
                                Notify(new NotifyEventArgs() { Message = "Repairing rod...\r\n" });

                                Point mouseTarget = GetMouseOffsetFromScreen(repairArea.X + (repairArea.Width / 2), repairArea.Y + (repairArea.Height / 2));

                                inputSimulator.Keyboard.KeyDown(inventoryKeybind).Sleep(150).KeyUp(inventoryKeybind).Sleep(300);
                                inputSimulator.Mouse.MoveMouseTo(mouseTarget.X, mouseTarget.Y).Sleep(500);
                                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.LCONTROL).KeyDown(VirtualKeyCode.VK_R).Mouse.LeftButtonDown().Sleep(150).LeftButtonUp().Sleep(25).Keyboard.KeyUp(VirtualKeyCode.LCONTROL).KeyUp(VirtualKeyCode.VK_R);
                                inputSimulator.Keyboard.KeyDown(inventoryKeybind).Sleep(150).KeyUp(inventoryKeybind).Sleep(500);
                                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.F3).Sleep(150).KeyUp(VirtualKeyCode.F3).Sleep(2000);

                                baitEquipped = false;
                            }

                            if (EquipBait && !baitEquipped)
                            {
                                Notify(new NotifyEventArgs() { Message = "Equipping bait...\r\n" });

                                Point baitTarget = GetMouseOffsetFromScreen(baitArea.X + (baitArea.Width / 2), baitArea.Y + (baitArea.Height / 2));
                                Point equipBaitTarget = GetMouseOffsetFromScreen(equipBaitArea.X + (equipBaitArea.Width / 2), equipBaitArea.Y + (equipBaitArea.Height / 2));

                                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_R).Sleep(100).KeyUp(VirtualKeyCode.VK_R).Sleep(200);
                                inputSimulator.Mouse.MoveMouseTo(baitTarget.X, baitTarget.Y).Sleep(200);
                                inputSimulator.Mouse.LeftButtonDown().Sleep(150).LeftButtonUp().Sleep(150);
                                inputSimulator.Mouse.MoveMouseTo(equipBaitTarget.X, equipBaitTarget.Y).Sleep(200);
                                inputSimulator.Mouse.LeftButtonDown().Sleep(150).LeftButtonUp().Sleep(2500);

                                baitEquipped = true;
                            }

                            if (afkMove)
                            {
                                Notify(new NotifyEventArgs() { Message = "Moving to prevent kick...\r\n" });

                                Point mouseTarget = GetMouseOffsetFromScreen(repairArea.X + (repairArea.Width / 2), repairArea.Y + (repairArea.Height / 2));

                                inputSimulator.Keyboard.KeyDown(inventoryKeybind).Sleep(150).KeyUp(inventoryKeybind).Sleep(300);
                                inputSimulator.Mouse.MoveMouseTo(mouseTarget.X, mouseTarget.Y).Sleep(500);
                                inputSimulator.Keyboard.KeyDown(inventoryKeybind).Sleep(150).KeyUp(inventoryKeybind).Sleep(500);
                                inputSimulator.Keyboard.KeyDown(VirtualKeyCode.F3).Sleep(150).KeyUp(VirtualKeyCode.F3).Sleep(2000);

                                afkMove = false;
                            }

                            if (!freeLooking)
                            {
                                inputSimulator.Keyboard.KeyDown(freeLookKeybind);
                                freeLooking = true;
                            }

                            Notify(new NotifyEventArgs() { Message = "Starting cast...\r\n" });

                            inputSimulator.Mouse.LeftButtonDown().Sleep(castTime).LeftButtonUp();

                            action = State.Casting;
                        }
                        break;
                    case State.Casting:
                        Image<Gray, float> hookImageMatch = targetImage.MatchTemplate(imageTemplates["hook"].Image, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
                        TemplateResult hookImageBestMatch = GetBestMatchFromTemplate(hookImageMatch);

                        hookImageMatch.Dispose();

                        if (hookImageBestMatch.value > imageTemplates["hook"].Tolerance)
                        {
                            targetImage.Dispose();

                            if (castStopwatch.IsRunning)
                                castStopwatch.Reset();

                            Notify(new NotifyEventArgs() { Message = "Found hook...\r\n" });
                            inputSimulator.Mouse.LeftButtonDown().Sleep(100).LeftButtonUp();
                            Notify(new NotifyEventArgs() { Message = "Starting reel...\r\n" });
                            action = State.Reel;                            
                            continue;
                        }

                        Image<Gray, float> castImageMatch = targetImage.MatchTemplate(imageTemplates["cast"].Image, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
                        TemplateResult castImageBestMatch = GetBestMatchFromTemplate(castImageMatch);

                        castImageMatch.Dispose();

                        if (castImageBestMatch.value > imageTemplates["cast"].Tolerance)
                        {
                            targetImage.Dispose();

                            if (castStopwatch.IsRunning)
                                castStopwatch.Reset();
                            continue;
                        }

                        if (!castStopwatch.IsRunning)
                            castStopwatch.Start();
                        else if (castStopwatch.IsRunning && castStopwatch.ElapsedMilliseconds > maxCastIdleTime)
                        {
                            Notify(new NotifyEventArgs() { Message = "Restarting...\r\n" });
                            targetImage.Dispose();
                            castStopwatch.Reset();
                            action = State.Idle;
                        }
                        break;
                    case State.Reel:
                        Image<Gray, float> reelImageMatch = targetImage.MatchTemplate(imageTemplates["reel"].Image, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
                        TemplateResult reelImageBestMatch = GetBestMatchFromTemplate(reelImageMatch);
                        reelImageMatch.Dispose();

                        if (reelImageBestMatch.value > imageTemplates["reel"].Tolerance)
                        {
                            if (reelStopwatch.IsRunning)
                                reelStopwatch.Reset();

                            ReelAction reelAction = GetReelAction(targetImage, reelImageBestMatch.point, imageTemplates["reel"].Image.Size);

                            if (reelAction == ReelAction.In && !reeling)
                            {
                                Notify(new NotifyEventArgs() { Message = "Reel in...\r\n" });
                                inputSimulator.Mouse.LeftButtonDown();
                                reeling = true;
                            }

                            if (reelAction == ReelAction.Out && reeling)
                            {
                                Notify(new NotifyEventArgs() { Message = "Reel out...\r\n" });
                                inputSimulator.Mouse.LeftButtonUp();
                                reeling = false;
                            }
                            continue;
                        }

                        if (!reelStopwatch.IsRunning)
                            reelStopwatch.Start();
                        else if (reelStopwatch.IsRunning && reelStopwatch.ElapsedMilliseconds > maxReelIdleTime)
                        {
                            Notify(new NotifyEventArgs() { Message = "Restarting...\r\n" });
                            targetImage.Dispose();
                            inputSimulator.Mouse.LeftButtonUp();
                            reeling = false;
                            reelStopwatch.Reset();
                            action = State.Idle;
                        }                        
                        break;
                }
            }
        }

        private void Error(ErrorEventArgs e)
        {
            CreateThread();
            working = false;
            ErrorEvent?.Invoke(this, e);
        }

        private void RunChanged(RunChangedEventArgs e)
        {
            RunChangedEvent?.Invoke(this, e);
        }

        private void Notify(NotifyEventArgs e)
        {
            NotifyEvent?.Invoke(this, e);
        }

        private TemplateResult GetBestMatchFromTemplate(Image<Gray, float> image)
        {
            double[] resultMin;
            double[] resultMax;
            Point[] resultPointMin;
            Point[] resultPointMax;
            TemplateResult bestMatch;

            image.MinMax(out resultMin, out resultMax, out resultPointMin, out resultPointMax);

            bestMatch.value = resultMax[0];
            bestMatch.point = resultPointMax[0];

            if (resultMax.Length == 1)
                return bestMatch;

            for (int i = 1; i < resultMax.Length; i++)
            {
                if (resultMax[i] > bestMatch.value)
                {
                    bestMatch.value = resultMax[i];
                    bestMatch.point = resultPointMax[i];
                }
            }

            return bestMatch;
        }

        private bool DoesPixelMatchColor(int match, double pixel, float tolerance)
        {
            int offset = (int)Math.Floor(255 - (255 * tolerance));
            return (match - offset) <= pixel && (match + offset) >= pixel;
        }

        private bool DoesPixelMatchRGB(Bgr pixel, ColorTemplate colorTemplate)
        {            
            if (!DoesPixelMatchColor(colorTemplate.Color.Value.R, pixel.Red, colorTemplate.Tolerance))
                return false;
            if (!DoesPixelMatchColor(colorTemplate.Color.Value.G, pixel.Green, colorTemplate.Tolerance))
                return false;
            if (!DoesPixelMatchColor(colorTemplate.Color.Value.B, pixel.Blue, colorTemplate.Tolerance))
                return false;
            return true;
        }

        private ReelAction GetReelAction(Image<Bgr, byte> image, Point offset, Size bounds)
        {
            for (int y = offset.Y; y < offset.Y + bounds.Height; y++)
            {
                for (int x = offset.X; x < offset.X + bounds.Width; x++)
                {
                    Bgr pixel = image[y, x];

                    if (DoesPixelMatchRGB(pixel, colorTemplates["reel_start"]))
                        return ReelAction.In;
                    if (DoesPixelMatchRGB(pixel, colorTemplates["reel_wait"]))
                        return ReelAction.Wait;
                    if (DoesPixelMatchRGB(pixel, colorTemplates["reel_stop"]))
                        return ReelAction.Out;
                }
            }

            return ReelAction.None;
        }

        private Point GetMouseOffsetFromScreen(int x, int y)
        {
            double xOffset = (double)(targetDisplay.Bounds.X + x) / Screen.PrimaryScreen.Bounds.Width;
            double yOffset = (double)(targetDisplay.Bounds.Y + y) / Screen.PrimaryScreen.Bounds.Height;

            return new Point((int)(xOffset * 65535), (int)(yOffset * 65535));
        }

        private bool Encumbered(Image<Bgr, Byte> image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Bgr pixel = image[y, x];
                    bool isEncumbered = DoesPixelMatchRGB(pixel, colorTemplates["encumbered"]);

                    if (isEncumbered)
                        return true;
                }
            }

            return false;
        }

        public void Start()
        {
            working = true;
            validated = false;
            runsCount = 0;
            RunChanged(new RunChangedEventArgs() { Count = runsCount });
            thread.Start();
        }

        public void Stop() {
            cancellationTokenSource.Cancel();
        }
        public Dictionary<string, ImageTemplate> GetImageTemplates()
        {
            return imageTemplates;
        }

        public Dictionary<string, ColorTemplate> GetColorTemplates()
        {
            return colorTemplates;
        }

        public void SetTargetDisplay(Screen _display)
        {
            targetDisplay = _display;
        }

        public void SetTargetArea(DisplayArea _target)
        {
            targetArea = _target;
        }

        public void SetRepairArea(DisplayArea _repair)
        {
            repairArea = _repair;
        }

        public void SetEncumberedArea(DisplayArea _encumbered)
        {
            encumberedArea = _encumbered;
        }

        public void SetBaitArea(DisplayArea _bait)
        {
            baitArea = _bait;
        }

        public void SetEquipBaitArea(DisplayArea _equipBait)
        {
            equipBaitArea = _equipBait;
        }

        public void SetCastPower(double percentage)
        {
            castTime = (int)Math.Floor(maxCastTime * percentage);
        }

        public void SetAFKTime(int mins)
        {
            afkTime = mins * 60000;
        }

        public void SetRepairAfterRunCount(int runs)
        {
            repairAfterRunCount = runs;
        }

        public void SetImageTemplate(string type, Image<Bgr, Byte> image)
        {
            if (type == null || image == null)
                return;
            if (!imageTemplates.ContainsKey(type))
                return;

            imageTemplates[type].Image = image;
        }

        public void SetColorTemplate(string type, Color color)
        {
            if (type == null)
                return;
            if (!colorTemplates.ContainsKey(type))
                return;
            colorTemplates[type].Color = color;
        }

        public void SetImageTemplateTolerance(string type, float tolerance)
        {
            if (type == null)
                return;
            if (!imageTemplates.ContainsKey(type))
                return;

            imageTemplates[type].Tolerance = tolerance;
        }

        public void SetColorTemplateTolerance(string type, float tolerance)
        {
            if (type == null)
                return;
            if (!colorTemplates.ContainsKey(type))
                return;

            colorTemplates[type].Tolerance = tolerance;
        }

        public event EventHandler<ErrorEventArgs> ErrorEvent;
        public event EventHandler<RunChangedEventArgs> RunChangedEvent;
        public event EventHandler<NotifyEventArgs> NotifyEvent;
    }

    public class ErrorEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    public class RunChangedEventArgs : EventArgs
    {
        public int Count { get; set; }
    }

    public class NotifyEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
