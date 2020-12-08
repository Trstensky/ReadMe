using ReadMeLib.Readers.Base;
using System.IO;
using System.Xml;

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
    }
}
