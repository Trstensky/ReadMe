using ReadMeLib.Readers.Base;
using System;
using System.Text;

namespace ReadMeLib.Readers {
    /// <summary>
    /// Reading encrypted text
    /// </summary>
    public class EncryptedReader:BaseReader {
        /// <summary>
        /// Save text for manipulating encryption
        /// </summary>
        /// <param name="text">Encrypted text of variable types</param>
        public EncryptedReader(string text) {
            Text = text;
        }

        /// <summary>
        /// Encrypt txt text from Base64 to string
        /// </summary>
        public override void ReadTxt() {
            try {
                byte[] data = Convert.FromBase64String(Text);
                Text = Encoding.UTF8.GetString(data);
            } catch { Text = "Base64 string is not valid!"; }
        }

        /// <summary>
        /// Encrypt xml text from hex to string
        /// </summary>
        public override void ReadXml() {
        }
    }
}
