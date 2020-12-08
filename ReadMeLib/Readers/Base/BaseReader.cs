﻿namespace ReadMeLib.Readers.Base {
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
    }
}
