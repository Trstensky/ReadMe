using ReadMeLib.Readers.Base;
using System.IO;

namespace ReadMeLib.Readers {
    public class FileReader:BaseReader {
        /// <summary>
        /// Save complete file path
        /// </summary>
        /// <param name="path">Complete path to file with file name</param>
        public FileReader(string path) {
            Path = path;
        }

        /// <summary>
        /// Reading text from txt file
        /// </summary>
        public override void ReadTxt() {
            // Check if particular file exist
            if(File.Exists(Path)) {
                try {
                    // Open the text file using a stream reader
                    using(var streamReader = new StreamReader(Path)) {
                        // Return text string
                        Text = streamReader.ReadToEnd();
                    }
                } catch {
                    Text = "Txt file is not valid!";
                }
            }
        }
    }
}
