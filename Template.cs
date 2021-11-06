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
    public class Template
    {
        public float Tolerance { get; set; } = 0.75f;

        public Template() { }
    }

    public class ImageTemplate : Template
    {
        public Image<Bgr, Byte> Image { get; set; } = null;

        public ImageTemplate() { }
    }

    public class ColorTemplate : Template
    {
        public Color? Color { get; set; } = null;

        public ColorTemplate() { }
    }

    public struct TemplateResult
    {
        public double value;
        public Point point;
    }
}
