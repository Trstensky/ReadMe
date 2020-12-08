using ReadMeLib.Model;
using ReadMeLib.Readers.Base;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Web.Script.Serialization;

namespace ReadMeLib.Readers {
    /// <summary>
    /// Reading admin text
    /// </summary>
    public class AdminReader:BaseReader {
        /// <summary>
        /// Save text
        /// </summary>
        /// <param name="text">Text of variable types</param>
        public AdminReader(string text) {
            Text = text;
        }

        /// <summary>
        /// Admin reading all txt lines
        /// </summary>
        public override void ReadTxt() {
            Text = Text;
        }

        /// <summary>
        /// Admin reading all xml nodes
        /// </summary>
        public override void ReadXml() {
            try {
                // Open xml file using xml document
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(Text);
                // Write unformated xml string and save string
                StringWriter stringWriter = new StringWriter();
                xmlDocument.Save(stringWriter);
                // Return formated xml string
                Text = stringWriter.ToString();
            } catch {
                Text = "Xml string is not in correct format!";
            }
        }

        /// <summary>
        /// Admin reading all json string
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
                }
                Text = join;
            } catch {
                Text = "Json string is not in correct format!";
            }
        }
    }
}
