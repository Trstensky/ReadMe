using ReadMeLib.Readers.Base;
using System.IO;
using System.Xml;
using System.Linq;

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
    }
}
