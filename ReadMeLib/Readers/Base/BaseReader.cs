namespace ReadMeLib.Readers.Base {
    public abstract class BaseReader {
        /// <summary>
        /// Complete path to text file with file name
        /// </summary>
        protected string Path {
            get; set;
        }

        /// <summary>
        /// Result string
        /// </summary>
        protected string Text {
            get; set;
        }

        /// <summary>
        /// Result string
        /// </summary>
        public string GetResult() {
            return Text;
        }

        /// <summary>
        /// Reading file type txt with file modes and file roles
        /// </summary>
        public abstract void ReadTxt();

        /// <summary>
        /// Reading file type xml with file modes and file roles
        /// </summary>
        public abstract void ReadXml();

        /// <summary>
        /// Reading file type json with file modes and file roles
        /// </summary>
        public abstract void ReadJson();
    }
}
