using ReadMeLib.Readers.Base;
using System;
using System.Linq;
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
            try {
                var bytes = new byte[Text.Length / 2];
                for(var i = 0; i < bytes.Length; i++) {
                    bytes[i] = Convert.ToByte(Text.Substring(i * 2, 2), 16);
                }
                Text = Encoding.UTF8.GetString(bytes);
            } catch { Text = "Hex string is not valid!"; }
        }

        /// <summary>
        /// Encrypt json text from reversed string to string
        /// </summary>
        public override void ReadJson() {
            try {
                Text = new string(Text.Reverse().ToArray());
            } catch {
                Text = "Reversed string is not valid!";
            }
        }
    }
}
