using ReadMeLib.Readers.Base;
using System.IO;
using System.Xml;
using System.Linq;
using ReadMeLib.Model;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace ReadMeLib.Readers {
    /// <summary>
    /// Reading guest text
    /// </summary>
    public class GuestReader:BaseReader {
        /// <summary>
        /// Save text
        /// </summary>
        /// <param name="text">Text of variable types</param>
        public GuestReader(string text) {
            Text = text;
        }

        /// <summary>
        /// Guest reading two txt lines
        /// </summary>
        public override void ReadTxt() {
            var result = Text.Split('\n').Take(2).ToArray();
            Text = string.Join("\n", result);
        }

        /// <summary>
        /// Guest reading one xml node
        /// </summary>
        public override void ReadXml() {
            try {
                // Open xml file using xml document
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(Text);
                // Write unformated xml string
                StringWriter stringWriter = new StringWriter();
                // Return one first xml node
                xmlDocument.LoadXml("<GuestCanReadOneLatestNode>" + xmlDocument.DocumentElement.FirstChild.OuterXml + "</GuestCanReadOneLatestNode>");
                xmlDocument.Save(stringWriter);
                // Return formated xml string
                Text = stringWriter.ToString();
            } catch {
                Text = "Xml string is not in correct format!";
            }
        }

        /// <summary>
        /// Guest reading one json item
        /// </summary>
        public override void ReadJson() {
            try {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var items = jss.Deserialize<List<Student>>(Text);
                var join = "";
                for(var i = 0; i < items.Count; i++) {
                    join += "RollNo is: " + items[i].RollNo + "\n";
                    join += "Name is: " + items[i].Name + "\n";
                    join += "Marks is: " + items[i].Marks + "\n\n";
                    i = items.Count;
                }
                Text = join;
            } catch {
                Text = "Json string is not in correct format!";
            }
        }
    }
}
