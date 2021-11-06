using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using WindowsInput.Native;
using System.Windows.Input;

namespace nw_fish
{
    public partial class frmMain : Form
    {
        private Fisher fisher;
        private Screen activeDisplay;
        private DisplayArea selectedArea;
        private DisplayArea targetArea;
        private DisplayArea repairArea;
        private DisplayArea encumberedArea;
        private DisplayArea baitArea;
        private DisplayArea equipBaitArea;
        private bool displayBoxMouseDown;
        private bool displayBoxMouseInBounds;
        private const int afkSliderOffset = 2;
        private const int repairAfterRunOffset = 10;

        public frmMain()
        {
            InitializeComponent();

            fisher = new Fisher();
            activeDisplay = null;
            selectedArea = null;
            targetArea = new DisplayArea("Target Area", Color.Red, 100, 100, 800, 800);
            repairArea = new DisplayArea("Repair Area", Color.Orange, 150, 300, 60, 60);
            encumberedArea = new DisplayArea("Encumbered Area", Color.Yellow, 150, 450, 60, 60);
            baitArea = new DisplayArea("Bait Area", Color.Blue, 150, 600, 60, 60);
            equipBaitArea = new DisplayArea("Equip Bait Area", Color.Green, 150, 750, 60, 60);
            displayBoxMouseDown = false;
            displayBoxMouseInBounds = false;

            fisher.ErrorEvent += fisher_Error;
            fisher.RunChangedEvent += fisher_RunChanged;
            fisher.NotifyEvent += fisher_Notify;

            fisher.SetTargetArea(targetArea);
            fisher.SetRepairArea(repairArea);
            fisher.SetEncumberedArea(encumberedArea);
            fisher.SetBaitArea(baitArea);
            fisher.SetEquipBaitArea(equipBaitArea);
        }

        private void populateDisplayCombobox()
        {
            Screen[] screens = Screen.AllScreens;

            displayCombo.Items.Clear();

            for (int i = 0; i < screens.Length; i++)
            {
                displayCombo.Items.Add(new DisplayComboboxItem(screens[i], i));
                if (screens[i].Primary)
                    displayCombo.SelectedIndex = displayCombo.Items.Count - 1;
            }
        }

        private void setDisplayImage()
        {
            if (activeDisplay == null)
                return;

            Bitmap frame = new Bitmap(activeDisplay.Bounds.Width, activeDisplay.Bounds.Height);

            using (Graphics g = Graphics.FromImage(frame))
            {
                g.CopyFromScreen(activeDisplay.Bounds.X, activeDisplay.Bounds.Y, 0, 0, frame.Size);

                if (targetAreaCheckbox.Checked)
                    targetArea.Draw(g);
                if (repairAreaCheckbox.Checked)
                    repairArea.Draw(g);
                if (encumberedAreaCheckbox.Checked)
                    encumberedArea.Draw(g);
                if (baitAreaCheckbox.Checked)
                    baitArea.Draw(g);
                if (equpBaitAreaCheckbox.Checked)
                    equipBaitArea.Draw(g);
            }

            if (displayBox.Image != null)
                displayBox.Image.Dispose();
            displayBox.Image = frame;
        }

        private void disableParentControls(Control parent, bool disable = true)
        {
            for (int i = 0; i < parent.Controls.Count; i++)
            {
                if (parent.Controls[i].GetType() == typeof(Button))
                    parent.Controls[i].Enabled = !disable;
            }
        }

        private void disableControls(bool disable = true)
        {
            displayCombo.Enabled = !disable;
            for (int i = 0; i < displayAreaGroup.Controls.Count; i++)
                displayAreaGroup.Controls[i].Enabled = !disable;
            for (int i = 0; i < templateImageGroup.Controls.Count; i++)
                templateImageGroup.Controls[i].Enabled = !disable;
            for (int i = 0; i < generalOptionsGroup.Controls.Count; i++)
                generalOptionsGroup.Controls[i].Enabled = !disable;
            for (int i = 0; i < presetsGroup.Controls.Count; i++)
                presetsGroup.Controls[i].Enabled = !disable;
        }

        private void setupTemplateImageBoxClick()
        {
            ToolTip templateToolTip = new ToolTip();
            string tipText = "Click to change";

            for (int i = 0; i < templateImageGroup.Controls.Count; i++)
            {
                var controlType = templateImageGroup.Controls[i].GetType();
                if (templateImageGroup.Controls[i] is ImageBox or PictureBox)
                {
                    templateToolTip.SetToolTip(templateImageGroup.Controls[i], tipText);
                    templateImageGroup.Controls[i].Click += new EventHandler(templateImageBox_Click);
                }
            }
        }

        private void setupTemplateInitialTolerances()
        {
            for (int i = 0; i < templateImageGroup.Controls.Count; i++)
            {
                if (templateImageGroup.Controls[i].Tag == null)
                    continue;

                string key = (string)templateImageGroup.Controls[i].Tag;

                if (templateImageGroup.Controls[i] is NumericUpDown)
                {
                    fisher.SetImageTemplateTolerance(key, (float)(templateImageGroup.Controls[i] as NumericUpDown).Value);
                    fisher.SetColorTemplateTolerance(key, (float)(templateImageGroup.Controls[i] as NumericUpDown).Value);
                }
            }
        }

        private bool templatesLoaded()
        {
            for (int i = 0; i < templateImageGroup.Controls.Count; i++)
            {
                if (templateImageGroup.Controls[i] is ImageBox)
                {
                    if ((templateImageGroup.Controls[i] as ImageBox).Image == null)
                        return false;
                }
            }

            return true;
        }

        private void setActivePreset(Preset preset)
        {
            preset.LoadArea(targetArea);
            preset.LoadArea(repairArea);
            preset.LoadArea(encumberedArea);
            preset.LoadArea(baitArea);
            preset.LoadArea(equipBaitArea);

            bool success;

            string _castPower = preset.LoadSetting("castPower");
            double castPower;
            success = double.TryParse(_castPower, out castPower);
            if (success)
            {
                fishCastPowerSlider.Value = (int)(fishCastPowerSlider.Maximum * castPower);
                fishCastPowerPercentage.Text = Math.Floor(castPower * 100) + "%";
                fisher.SetCastPower(castPower);
            }

            string _afkMinutes = preset.LoadSetting("afkMinutes");
            int afkMinutes;
            success = int.TryParse(_afkMinutes, out afkMinutes);
            if (success)
            {
                fishAfkTimeSlider.Value = afkMinutes / afkSliderOffset;
                fishAfkTimeLabel.Text = $"Move after {afkMinutes} minutes";
                fisher.SetAFKTime(afkMinutes);
            }

            string _afkEnabled = preset.LoadSetting("afkEnabled");
            bool afkEnabled;
            success = bool.TryParse(_afkEnabled, out afkEnabled);
            if (success)
            {
                fishAfkTimeCheckbox.Checked = afkEnabled;
                fisher.AntiAFK = afkEnabled;
            }

            string _repairRunCount = preset.LoadSetting("repairRunCount");
            int repairRunCount;
            success = int.TryParse(_repairRunCount, out repairRunCount);
            if (success)
            {
                fishRepairSlider.Value = repairRunCount / repairAfterRunOffset;
                fisher.SetRepairAfterRunCount(repairRunCount);
            }

            string _freeLookKeybind = preset.LoadSetting("freeLookKeybind");
            int freeLookKeybind;
            success = int.TryParse(_freeLookKeybind, out freeLookKeybind);
            if (success)
            {
                fishFreeLookKeybindCombo.SelectedItem = (Keys)freeLookKeybind;
                fisher.FreeLookKeybind = (VirtualKeyCode)freeLookKeybind;
            }

            string _freeLookEnabled = preset.LoadSetting("freeLookEnabled");
            bool freeLookEnabled;
            success = bool.TryParse(_freeLookEnabled, out freeLookEnabled);
            if (success)
            {
                fishFreeLookKeybindCheckbox.Checked = freeLookEnabled;
                fisher.FreeLook = freeLookEnabled;
            }

            string _inventoryKeybind = preset.LoadSetting("inventoryKeybind");
            int inventoryKeybind;
            success = int.TryParse(_inventoryKeybind, out inventoryKeybind);
            if (success)
            {
                fishInventoryKeybindCombo.SelectedItem = (Keys)inventoryKeybind;
                fisher.InventoryKeybind = (VirtualKeyCode)inventoryKeybind;
            }

            string _stopWhenEncumbered = preset.LoadSetting("stopWhenEncumbered");
            bool stopWhenEncumbered;
            success = bool.TryParse(_stopWhenEncumbered, out stopWhenEncumbered);
            if (success)
            {
                fishEncumberedCheckbox.Checked = stopWhenEncumbered;
                fisher.StopWhenEncumbered = stopWhenEncumbered;
            }

            string _equpBait = preset.LoadSetting("equpBait");
            bool equpBait;
            success = bool.TryParse(_equpBait, out equpBait);
            if (success)
            {
                fishBaitCheckbox.Checked = equpBait;
                fisher.EquipBait = equpBait;
            }

            Dictionary<string, Template> presetTemplates = new Dictionary<string, Template>();

            for (int i = 0; i < templateImageGroup.Controls.Count; i++)
            {
                if (templateImageGroup.Controls[i].Tag == null)
                    continue;

                string key = (string)templateImageGroup.Controls[i].Tag;

                if (!presetTemplates.ContainsKey(key))
                    presetTemplates[key] = preset.GetTemplate(key);

                if (templateImageGroup.Controls[i] is NumericUpDown)
                {
                    (templateImageGroup.Controls[i] as NumericUpDown).Value = (decimal)presetTemplates[key].Tolerance;
                }
                else if (templateImageGroup.Controls[i] is ImageBox)
                {
                    (templateImageGroup.Controls[i] as ImageBox).Image = (presetTemplates[key] as ImageTemplate).Image;
                    fisher.SetImageTemplate(key, (presetTemplates[key] as ImageTemplate).Image);
                    fisher.SetImageTemplateTolerance(key, (presetTemplates[key] as ImageTemplate).Tolerance);
                }
                else if (templateImageGroup.Controls[i] is PictureBox)
                {
                    (templateImageGroup.Controls[i] as PictureBox).BackColor = (presetTemplates[key] as ColorTemplate).Color.Value;
                    fisher.SetColorTemplate(key, (presetTemplates[key] as ColorTemplate).Color.Value);
                    fisher.SetColorTemplateTolerance(key, (presetTemplates[key] as ColorTemplate).Tolerance);
                }
            }
        }

        private void displayTimer_Tick(object sender, EventArgs e)
        {
            setDisplayImage();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            populateDisplayCombobox();
            setupTemplateImageBoxClick();
            setupTemplateInitialTolerances();

            foreach (var item in Enum.GetValues(typeof(VirtualKeyCode)))
            {
                fishFreeLookKeybindCombo.Items.Add((Keys)item);
                fishInventoryKeybindCombo.Items.Add((Keys)item);
            }
            fishFreeLookKeybindCombo.SelectedItem = (Keys)fisher.FreeLookKeybind;
            fishInventoryKeybindCombo.SelectedItem = (Keys)fisher.InventoryKeybind;
            fishFreeLookKeybindCheckbox.Checked = fisher.FreeLook;
            fishEncumberedCheckbox.Checked = fisher.StopWhenEncumbered;
            fishBaitCheckbox.Checked = fisher.EquipBait;
            fishCastPowerSlider.Value = fishCastPowerSlider.Minimum;
            fishCastPowerSlider.Value = fishCastPowerSlider.Maximum;
            fishAfkTimeSlider.Value = fishAfkTimeSlider.Maximum;
            fishAfkTimeSlider.Value = fishAfkTimeSlider.Minimum;
            fishRepairSlider.Value = fishRepairSlider.Maximum;
            fishRepairSlider.Value = fishRepairSlider.Minimum;
            fishRunCountLabel.Text = $"Runs: {fisher.Runs}";
        }

        private void displayCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeDisplay = (Screen)(displayCombo.SelectedItem as DisplayComboboxItem).Value;
            targetArea.Reset(true);
            repairArea.Reset(true);
            encumberedArea.Reset(true);
            baitArea.Reset(true);
            equipBaitArea.Reset(true);
            fisher.SetTargetDisplay(activeDisplay);
        }

        private void displayBox_MouseDown(object sender, MouseEventArgs e)
        {
            displayBoxMouseDown = true;

            if (!displayBoxMouseInBounds)
                return;
            if (selectedArea == null)
                return;

            double xOffset = (double)e.X / displayBox.Width;
            double yOffset = (double)e.Y / displayBox.Height;

            int x = (int)(displayBox.Image.Width * xOffset);
            int y = (int)(displayBox.Image.Height * yOffset);

            if (selectedArea.Contains(x, y))
            {
                selectedArea.MoveOffsetX = x - selectedArea.X;
                selectedArea.MoveOffsetY = y - selectedArea.Y;
                selectedArea.Moving = true;
                selectedArea.MoveType = selectedArea.OnBorder(x, y);
            }
        }

        private void displayBox_MouseUp(object sender, MouseEventArgs e)
        {
            displayBoxMouseDown = false;

            if (selectedArea == null)
                return;

            selectedArea.Moving = false;
        }

        private void displayBox_MouseEnter(object sender, EventArgs e)
        {
            displayBoxMouseInBounds = true;
        }

        private void displayBox_MouseLeave(object sender, EventArgs e)
        {
            displayBoxMouseInBounds = false;
        }

        private void displayBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!displayBoxMouseInBounds)
                return;
            if (selectedArea == null)
                return;

            double xOffset = (double)e.X / displayBox.Width;
            double yOffset = (double)e.Y / displayBox.Height;

            int x = (int)(displayBox.Image.Width * xOffset);
            int y = (int)(displayBox.Image.Height * yOffset);

            //Show possible resize/movement options when hovered
            if (!displayBoxMouseDown)
            {
                if (selectedArea.Contains(x, y))
                {
                    switch(selectedArea.OnBorder(x, y))
                    {
                        case DisplayArea.Border.None:
                            Cursor.Current = Cursors.SizeAll;
                            break;
                        case DisplayArea.Border.North:
                        case DisplayArea.Border.South:
                            Cursor.Current = Cursors.SizeNS;
                            break;
                        case DisplayArea.Border.East:
                        case DisplayArea.Border.West:
                            Cursor.Current = Cursors.SizeWE;
                            break;
                    }
                }
            }

            if (displayBoxMouseDown && selectedArea.Moving)
            {
                //Go to selected resize/movement type
                switch (selectedArea.MoveType)
                {
                    //Move area
                    case DisplayArea.Border.None:
                        Cursor.Current = Cursors.SizeAll;

                        x -= selectedArea.MoveOffsetX;
                        y -= selectedArea.MoveOffsetY;

                        if (x + selectedArea.Width > displayBox.Image.Width)
                            x = displayBox.Image.Width - selectedArea.Width;
                        else if (x < 0)
                            x = 0;

                        if (y + selectedArea.Height > displayBox.Image.Height)
                            y = displayBox.Image.Height - selectedArea.Height;
                        else if (y < 0)
                            y = 0;

                        selectedArea.X = x;
                        selectedArea.Y = y;
                        break;
                    //Increase/Decrease area sizes
                    case DisplayArea.Border.North:
                        Cursor.Current = Cursors.SizeNS;

                        int northOffset = selectedArea.Y - y;

                        selectedArea.Y -= northOffset;
                        selectedArea.Height += northOffset;

                        if (selectedArea.Height < selectedArea.MinHeight)
                        {
                            int temp = selectedArea.MinHeight - selectedArea.Height;
                            selectedArea.Y -= temp;
                            selectedArea.Height += temp;
                        }

                        if (selectedArea.Y < 0)
                        {
                            int temp = 0 - selectedArea.Y;
                            selectedArea.Y += temp;
                            selectedArea.Height -= temp;
                        }
                        break;
                    case DisplayArea.Border.South:
                        Cursor.Current = Cursors.SizeNS;

                        int southOffset = y - (selectedArea.Y + selectedArea.Height);

                        selectedArea.Height += southOffset;

                        if (selectedArea.Y + selectedArea.Height > displayBox.Image.Height)
                            selectedArea.Height -= (selectedArea.Y + selectedArea.Height) - displayBox.Image.Height;

                        if (selectedArea.Height < selectedArea.MinHeight)
                            selectedArea.Height = selectedArea.MinHeight;
                        break;
                    case DisplayArea.Border.East:
                        Cursor.Current = Cursors.SizeWE;

                        int eastOffset = x - (selectedArea.X + selectedArea.Width);

                        selectedArea.Width += eastOffset;

                        if (selectedArea.X + selectedArea.Width > displayBox.Image.Width)
                            selectedArea.Width -= (selectedArea.X + selectedArea.Width) - displayBox.Image.Width;

                        if (selectedArea.Width < selectedArea.MinWidth)
                            selectedArea.Width = selectedArea.MinWidth;
                        break;
                    case DisplayArea.Border.West:
                        Cursor.Current = Cursors.SizeWE;
                        int westOffset = selectedArea.X - x;

                        selectedArea.X -= westOffset;
                        selectedArea.Width += westOffset;

                        if (selectedArea.Width < selectedArea.MinWidth)
                        {
                            int temp = selectedArea.MinWidth - selectedArea.Width;
                            selectedArea.X -= temp;
                            selectedArea.Width += temp;
                        }

                        if (selectedArea.X < 0)
                        {
                            int temp = 0 - selectedArea.X;
                            selectedArea.X += temp;
                            selectedArea.Width -= temp;
                        }
                        break;
                }
            }
        }

        private void targetAreaEditButton_Click(object sender, EventArgs e)
        {
            if (targetArea.Equals(selectedArea))
            {
                selectedArea = null;
                targetArea.Reset();
                targetAreaEditButton.Text = "Edit";
                disableParentControls(targetAreaEditButton.Parent, false);
                return;
            }

            disableParentControls(targetAreaEditButton.Parent, true);
            selectedArea = targetArea;
            targetAreaEditButton.Text = "Finish";
            targetAreaEditButton.Enabled = true;            
        }

        private void repairAreaEditButton_Click(object sender, EventArgs e)
        {
            if (repairArea.Equals(selectedArea))
            {
                selectedArea = null;
                repairArea.Reset();
                repairAreaEditButton.Text = "Edit";
                disableParentControls(repairAreaEditButton.Parent, false);
                return;
            }

            disableParentControls(repairAreaEditButton.Parent, true);
            selectedArea = repairArea;
            repairAreaEditButton.Text = "Finish";
            repairAreaEditButton.Enabled = true;
        }

        private void encumberedAreaEditButton_Click(object sender, EventArgs e)
        {
            if (encumberedArea.Equals(selectedArea))
            {
                selectedArea = null;
                encumberedArea.Reset();
                encumberedAreaEditButton.Text = "Edit";
                disableParentControls(encumberedAreaEditButton.Parent, false);
                return;
            }

            disableParentControls(encumberedAreaEditButton.Parent, true);
            selectedArea = encumberedArea;
            encumberedAreaEditButton.Text = "Finish";
            encumberedAreaEditButton.Enabled = true;
        }

        private void baitAreaEditButton_Click(object sender, EventArgs e)
        {
            if (baitArea.Equals(selectedArea))
            {
                selectedArea = null;
                baitArea.Reset();
                baitAreaEditButton.Text = "Edit";
                disableParentControls(baitAreaEditButton.Parent, false);
                return;
            }

            disableParentControls(baitAreaEditButton.Parent, true);
            selectedArea = baitArea;
            baitAreaEditButton.Text = "Finish";
            baitAreaEditButton.Enabled = true;
        }

        private void equipBaitAreaEditButton_Click(object sender, EventArgs e)
        {
            if (equipBaitArea.Equals(selectedArea))
            {
                selectedArea = null;
                equipBaitArea.Reset();
                equipBaitAreaEditButton.Text = "Edit";
                disableParentControls(equipBaitAreaEditButton.Parent, false);
                return;
            }

            disableParentControls(equipBaitAreaEditButton.Parent, true);
            selectedArea = equipBaitArea;
            equipBaitAreaEditButton.Text = "Finish";
            equipBaitAreaEditButton.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (fisher.Working)
            {
                fisher.Stop();
                startButton.Text = "Start";
                disableControls(false);
                return;
            }

            if (!templatesLoaded())
            {
                MessageBox.Show("Not all template images are available!");
                return;
            }

            if (selectedArea != null)
            {
                MessageBox.Show("Area editing needs to be disabled!");
                return;
            }

            disableControls(true);
            startButton.Text = "Stop";
            fisher.Start();
        }

        private void fisher_Error(object sender, ErrorEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                if (e.Message != null)
                    MessageBox.Show(e.Message);

                startButton.Text = "Start";
                disableControls(false);
            }));

        }

        private void fisher_RunChanged(object sender, RunChangedEventArgs e)
        {
            //fishRunCountLabel.Text = "Runs: " + e.Count;
            this.Invoke(new MethodInvoker(delegate
            {
                fishRunCountLabel.Text = "Runs: " + e.Count;
            }));
        }

        private void fisher_Notify(object sender, NotifyEventArgs e)
        {
            //fishConsoleOutput.AppendText(e.Message);
            this.Invoke(new MethodInvoker(delegate
            {
                fishConsoleOutput.AppendText(e.Message);
            }));
        }

        private void templateImageBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog() { Filter = "PNG Files (*.png)|*.png" };
            DialogResult dialogResult = fileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (sender is ImageBox)
                {
                    ImageBox tempBox = (ImageBox)sender;
                    tempBox.Image = new Image<Bgr, Byte>(fileDialog.FileName);
                    fisher.SetImageTemplate((string)tempBox.Tag, (Image<Bgr, Byte>)tempBox.Image);
                }
                else
                {
                    Bitmap tempImg = (Bitmap)Image.FromFile(fileDialog.FileName);
                    PictureBox tempBox = (PictureBox)sender;
                    tempBox.BackColor = tempImg.GetPixel(0, 0);

                    fisher.SetColorTemplate((string)tempBox.Tag, tempBox.BackColor);
                }
            }
                
        }

        private void fishReelStartPicker_ColorChanged(object sender, EventArgs e)
        {
            fishReelStartBox.BackColor = fishReelStartPicker.Color;
            fisher.SetColorTemplate((string)fishReelStartBox.Tag, fishReelStartBox.BackColor);
        }

        private void fishReelWaitPicker_ColorChanged(object sender, EventArgs e)
        {
            fishReelWaitBox.BackColor = fishReelWaitPicker.Color;
            fisher.SetColorTemplate((string)fishReelWaitBox.Tag, fishReelWaitBox.BackColor);
        }

        private void fishReelStopPicker_ColorChanged(object sender, EventArgs e)
        {
            fishReelStopBox.BackColor = fishReelStopPicker.Color;
            fisher.SetColorTemplate((string)fishReelStopBox.Tag, fishReelStopBox.BackColor);
        }

        private void fishEncumberedPicker_ColorChanged(object sender, EventArgs e)
        {
            fishEncumberedBox.BackColor = fishEncumberedPicker.Color;
            fisher.SetColorTemplate((string)fishEncumberedBox.Tag, fishEncumberedBox.BackColor);
        }

        private void templateImageTolerance_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown tempNum = (NumericUpDown)sender;
            fisher.SetImageTemplateTolerance((string)tempNum.Tag, (float)tempNum.Value);
        }

        private void templateColorTolerance_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown tempNum = (NumericUpDown)sender;
            fisher.SetColorTemplateTolerance((string)tempNum.Tag, (float)tempNum.Value);
        }

        private void fishCastPowerSlider_ValueChanged(object sender, EventArgs e)
        {
            double percentage = (double)fishCastPowerSlider.Value / fishCastPowerSlider.Maximum;
            fishCastPowerPercentage.Text = Math.Floor(percentage * 100) + "%";
            fisher.SetCastPower(percentage);
        }

        private void fishAfkTimeSlider_ValueChanged(object sender, EventArgs e)
        {
            int minutes = fishAfkTimeSlider.Value * afkSliderOffset;
            fishAfkTimeLabel.Text = $"Move after {minutes} minutes";
            fisher.SetAFKTime(minutes);
        }

        private void fishAfkTimeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            fisher.AntiAFK = fishAfkTimeCheckbox.Checked;
        }

        private void fishRepairSlider_ValueChanged(object sender, EventArgs e)
        {
            int runs = fishRepairSlider.Value * repairAfterRunOffset;
            fishRepairLabel.Text = $"Repair after {runs} runs";
            fisher.SetRepairAfterRunCount(runs);
        }

        private void fishFreeLookKeybindCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fisher.FreeLookKeybind = (VirtualKeyCode)Enum.Parse(typeof(Keys), fishFreeLookKeybindCombo.SelectedItem.ToString());
        }

        private void fishFreeLookKeybindCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            fisher.FreeLook = fishFreeLookKeybindCheckbox.Checked;
        }

        private void fishInventoryKeybindCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            fisher.InventoryKeybind = (VirtualKeyCode)Enum.Parse(typeof(Keys), fishInventoryKeybindCombo.SelectedItem.ToString());
        }

        private void fishEncumberedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            fisher.StopWhenEncumbered = fishEncumberedCheckbox.Checked;
        }

        private void fishBaitCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            fisher.EquipBait = fishBaitCheckbox.Checked;
        }

        private void presetsSaveButton_Click(object sender, EventArgs e)
        {
            disableControls(true);

            Preset preset = new Preset();

            preset.SetTemplates(fisher.GetImageTemplates(), fisher.GetColorTemplates());

            preset.AddArea(targetArea);
            preset.AddArea(repairArea);
            preset.AddArea(encumberedArea);
            preset.AddArea(baitArea);
            preset.AddArea(equipBaitArea);

            preset.AddSetting("castPower", (double)fishCastPowerSlider.Value / fishCastPowerSlider.Maximum);
            preset.AddSetting("afkMinutes", fishAfkTimeSlider.Value * afkSliderOffset);
            preset.AddSetting("afkEnabled", fishAfkTimeCheckbox.Checked);
            preset.AddSetting("repairRunCount", fishRepairSlider.Value * repairAfterRunOffset);
            preset.AddSetting("freeLookKeybind", (int)fisher.FreeLookKeybind);
            preset.AddSetting("freeLookEnabled", fisher.FreeLook);
            preset.AddSetting("inventoryKeybind", (int)fisher.InventoryKeybind);
            preset.AddSetting("stopWhenEncumbered", fisher.StopWhenEncumbered);
            preset.AddSetting("equpBait", fisher.EquipBait);

            preset.Save();

            disableControls(false);
        }

        private void presetsLoadButton_Click(object sender, EventArgs e)
        {
            Preset preset = new Preset();

            bool isLoaded = preset.Load();

            if (isLoaded)
            {
                presetsCombo.Items.Add(preset);
                presetsCombo.SelectedIndex = presetsCombo.Items.Count - 1;
            }
        }

        private void presetsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Preset preset = (Preset)presetsCombo.SelectedItem;
            setActivePreset(preset);
        }
        //test
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
    }
}
