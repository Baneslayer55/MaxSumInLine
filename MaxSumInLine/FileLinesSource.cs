using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumInLine
{
    public class FileLinesSource : ILinesSource
    {
        private FileStream importedFile;

        private StreamReader readFile;

        public FileLinesSource(string filePath)
        {
            importedFile = new FileStream(filePath, FileMode.Open);
            readFile = new StreamReader(importedFile);
        }

        public bool TryGetNextLine(out string nextLine)
        {
            if (readFile.Peek() >= 0)
            {
                nextLine = readFile.ReadLine();
                return true;
            }
            else
            {
                nextLine = null;
                importedFile.Close();
                return false;
            }            
        }
    }
}
