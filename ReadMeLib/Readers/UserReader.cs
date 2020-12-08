using ReadMeLib.Model;
using ReadMeLib.Readers.Base;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Web.Script.Serialization;

namespace ReadMeLib.Readers {
    /// <summary>
    /// Reading user text
    /// </summary>
    public class UserReader:BaseReader {
        /// <summary>
        /// Save text
        /// </summary>
        /// <param name="text">Text of variable types</param>
        public UserReader(string text) {
            Text = text;
        }

        /// <summary>
        /// User reading four txt lines
        /// </summary>
        public override void ReadTxt() {
            var result = Text.Split('\n').Take(4).ToArray();
            Text = string.Join("\n", result);
        }

        /// <summary>
        /// User reading two xml nodes
        /// </summary>
        public override void ReadXml() {
            try {
                // Open xml text using xml document
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(Text);
                // Write unformated xml string
                StringWriter stringWriter = new StringWriter();
                // Return first three nodes
                var nodes = xmlDocument.DocumentElement.FirstChild.OuterXml;
                nodes += xmlDocument.DocumentElement.FirstChild.NextSibling.OuterXml;
                xmlDocument.LoadXml("<UserCanReadTwoLatestNodes>" + nodes + "</UserCanReadTwoLatestNodes>");
                xmlDocument.Save(stringWriter);
                // Return formated xml string
                Text = stringWriter.ToString();
            } catch {
                Text = "Xml string is not in correct format!";
            }
        }

        /// <summary>
        /// User reading two json items
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
                    if(i == 1) {
                        i = items.Count;
                    }
                }
                Text = join;
            } catch {
                Text = "Json string is not in correct format!";
            }
        }
    }
}
