using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using WindowsInput.Native;
using System.Windows.Forms;
using System.IO;

namespace nw_fish
{
    public class Preset
    {
        private XDocument data;
        private XElement templates;
        private XElement areas;
        private XElement settings;
        private Dictionary<string, Image<Bgr, Byte>> savedImages;

        public string Name { get; set; }

        public Preset()
        {
            data = new XDocument(
                new XElement("Preset")
            );
            areas = new XElement("Areas");
            settings = new XElement("Settings");
            savedImages = new Dictionary<string, Image<Bgr, byte>>();
        }

        public void SetTemplates(Dictionary<string, ImageTemplate> imageTemplates, Dictionary<string, ColorTemplate> colorTemplates)
        {
            templates = new XElement("Templates");

            foreach (var item in imageTemplates)
            {
                if (item.Value.Image != null)
                    savedImages.Add(item.Key, item.Value.Image);
                templates.Add(
                    new XElement("Item",
                        new XAttribute("type", "image"),
                        new XElement("Name", item.Key),
                        new XElement("Tolerance", item.Value.Tolerance)
                    )
                );
            }

            foreach (var item in colorTemplates)
            {
                Color color = item.Value.Color.GetValueOrDefault();
                templates.Add(
                    new XElement("Item",
                        new XAttribute("type", "color"),
                        new XElement("Name", item.Key),
                        new XElement("Tolerance", item.Value.Tolerance),
                        new XElement("Color",
                            new XAttribute("R", (int)color.R),
                            new XAttribute("G", (int)color.G),
                            new XAttribute("B", (int)color.B) 
                        )
                    )
                );
            }
        }

        public void AddArea(DisplayArea area)
        {
            areas.Add(
                new XElement("Item",
                    new XElement("Name", area.Label),
                    new XElement("X", area.X),
                    new XElement("Y", area.Y),
                    new XElement("Width", area.Width),
                    new XElement("Height", area.Height)
                )
            );
        }

        public void AddSetting(string option, object value)
        {
            settings.Add(new XElement(option, value));
        }

        public void Save()
        {
            data.Root.Add(templates, areas, settings);

            SaveFileDialog saveDialog = new SaveFileDialog() { Filter = "XML-File | *.xml" };
            DialogResult dialogResult = saveDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                data.Save(saveDialog.FileName);

                if (savedImages.Count > 0)
                {
                    string presetPath = Path.GetDirectoryName(saveDialog.FileName);
                    string presetName = Path.GetFileNameWithoutExtension(saveDialog.FileName);
                    string presetData = Path.Combine(presetPath, presetName + "-data");

                    Directory.CreateDirectory(presetData);

                    foreach (var item in savedImages)
                    {
                        item.Value.Save(Path.Combine(presetData, item.Key + ".png"));
                    }
                }
            }
        }

        public bool Load()
        {
            OpenFileDialog fileDialog = new OpenFileDialog() { Filter = "XML-File | *.xml" };
            DialogResult dialogResult = fileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                data = XDocument.Load(fileDialog.FileName);

                if (!data.Root.IsEmpty && data.Root.HasElements)
                {
                    if (data.Root.Name.LocalName != "Preset")
                    {
                        return false;
                    }

                    string presetPath = Path.GetDirectoryName(fileDialog.FileName);
                    string presetName = Path.GetFileNameWithoutExtension(fileDialog.FileName);
                    string presetData = Path.Combine(presetPath, presetName + "-data");

                    Name = presetName;

                    if (Directory.Exists(presetData))
                    {
                        XElement xTemplates = data.Root.Element("Templates");

                        foreach (XElement item in xTemplates.Elements("Item"))
                        {
                            if (item.Attribute("type").Value != "image")
                                continue;

                            string imageKey = item.Element("Name").Value;
                            string imageLocation = Path.Combine(presetData, imageKey + ".png");

                            if (File.Exists(imageLocation))
                            {
                                savedImages[imageKey] = new Image<Bgr, Byte>(imageLocation);
                            }
                        }
                    }
                }

                return true;
            }

            return false;
        }

        public void LoadArea(DisplayArea area) //needs validation
        {
            XElement xArea = data.Root.Element("Areas").Elements("Item").First(item => item.Element("Name").Value == area.Label);

            if (xArea == null)
                return;

            int value;
            bool success = int.TryParse(xArea.Element("X").Value, out value);
            
            if (success)
                area.X = value;

            success = int.TryParse(xArea.Element("Y").Value, out value);
            if (success)
                area.Y = value;

            success = int.TryParse(xArea.Element("Width").Value, out value);
            if (success)
                area.Width = value;

            success = int.TryParse(xArea.Element("Height").Value, out value);
            if (success)
                area.Height = value;
        }

        public string LoadSetting(string name) //needs validation
        {
            return data.Root.Element("Settings").Element(name).Value;
        }

        public Template GetTemplate(string name) //needs validation
        {
            XElement xTemplate = data.Root.Element("Templates").Elements("Item").First(item => item.Element("Name").Value == name);
            Template template;

            if (xTemplate.Attribute("type").Value == "image")
            {
                template = new ImageTemplate();
                if (savedImages.ContainsKey(name))
                    (template as ImageTemplate).Image = savedImages[name];
            } 
            else
            {
                template = new ColorTemplate();
                int red, green, blue;
                bool redSuccess = int.TryParse(xTemplate.Element("Color").Attribute("R").Value, out red);
                bool greenSuccess = int.TryParse(xTemplate.Element("Color").Attribute("G").Value, out green);
                bool blueSuccess = int.TryParse(xTemplate.Element("Color").Attribute("B").Value, out blue);

                if (redSuccess && greenSuccess && blueSuccess)
                    (template as ColorTemplate).Color = Color.FromArgb(red, green, blue);
            }

            float value;
            bool success = float.TryParse(xTemplate.Element("Tolerance").Value, out value);
            if (success)
                template.Tolerance = value;

            return template;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
