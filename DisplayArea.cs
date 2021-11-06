using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace nw_fish
{
    public class DisplayArea : IEquatable<object>
    {
        private Rectangle rectangle;
        private Point rectanglePoint;
        private Size rectangleSize;
        private Pen rectanglePen;
        private string text;
        private SolidBrush textBrush;
        private Font textFont;
        private const float penSize = 5.0f;
        private const float fontSize = 50.0f;
        private const float textOffset = 1.5f;
        
        public int X
        {
            get { return rectangle.X; }
            set { rectangle.X = value; }
        }
        public int Y
        {
            get { return rectangle.Y; }
            set { rectangle.Y = value; }
        }
        public int Width
        {
            get { return rectangle.Width; }
            set { rectangle.Width = value; }
        }
        public int Height
        {
            get { return rectangle.Height; }
            set { rectangle.Height = value; }
        }
        public float BorderSize
        {
            get { return rectanglePen.Width; }
            set { rectanglePen.Width = value; }
        }
        public int MinWidth
        {
            get { return (int)BorderSize * 2 * 3; }
        }
        public int MinHeight
        {
            get { return (int)BorderSize * 2 * 3; } //* 2 for safety (* 3) for (top - middle - bottom) room
        }
        public enum Border
        {
            None = 0,
            North,
            South,
            East,
            West,
        }
        public int MoveOffsetX { get; set; } = 0;
        public int MoveOffsetY { get; set; } = 0;
        public bool Moving { get; set; } = false;
        public Border MoveType { get; set; } = Border.None;
        public string Label { get => text; }

        public DisplayArea(string name, Color color, int x = 150, int y = 150, int width = 200, int height = 200)
        {
            rectangle = new Rectangle(x, y, width, height);
            rectanglePoint = new Point(x, y);
            rectangleSize = new Size(width, height);
            rectanglePen = new Pen(color, penSize);
            text = name;
            textBrush = new SolidBrush(color);
            textFont = new Font(FontFamily.GenericSansSerif, fontSize);
        }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(rectanglePen, rectangle);
            g.DrawString(text, textFont, textBrush, rectangle.X, rectangle.Y - (fontSize * textOffset));
        }

        public void Reset(bool full = false)
        {
            if (full)
            {
                rectangle.X = rectanglePoint.X;
                rectangle.Y = rectanglePoint.Y;
                rectangle.Width = rectangleSize.Width;
                rectangle.Height = rectangleSize.Height;
            }

            MoveOffsetX = 0;
            MoveOffsetY = 0;
            Moving = false;
            MoveType = Border.None;
        }

        public bool Contains(int x, int y) {
            return rectangle.Contains(x, y);
        }

        public Border OnBorder(int x, int y)
        {
            int xOffset = x - X;
            int yOffset = y - Y;
            float borderOffset = BorderSize * 2;

            if (yOffset <= borderOffset)
                return Border.North;
            if (yOffset >= Height - borderOffset)
                return Border.South;
            if (xOffset <= borderOffset)
                return Border.West;
            if (xOffset >= Width - borderOffset)
                return Border.East;

            return Border.None;
        }

        public Image<Bgr, Byte> GetImage()
        {
            Bitmap frame = new Bitmap(Width, Height);

            using (Graphics g = Graphics.FromImage(frame))
            {
                g.CopyFromScreen(X, Y, 0, 0, frame.Size);
            }

            Image<Bgr, Byte> frameImage = frame.ToImage<Bgr, Byte>();
            frame.Dispose();

            return frameImage;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is DisplayArea))
                return false;
            return (this.Label == ((DisplayArea)obj).Label) && (this.X == ((DisplayArea)obj).X) && (this.Y == ((DisplayArea)obj).Y) && (this.Width == ((DisplayArea)obj).Width) && (this.Height == ((DisplayArea)obj).Height);
        }

        public override int GetHashCode()
        {
            return this.Label.GetHashCode() + this.X.GetHashCode() + this.Y.GetHashCode() + this.Width.GetHashCode() + this.Height.GetHashCode();
        }
    }
}
