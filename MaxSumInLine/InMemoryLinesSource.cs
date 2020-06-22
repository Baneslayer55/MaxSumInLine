using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumInLine
{
    public class InMemoryLinesSource:ILinesSource
    {
        private string[] inMemoryLines;

        private int lineCount = 0;

        public InMemoryLinesSource(string[] inMemoryLines)
        {
            this.inMemoryLines = inMemoryLines;
        }

        public bool TryGetNextLine(out string nextLine)
        {
            if (inMemoryLines.Length > lineCount)
            {                
                nextLine = inMemoryLines[lineCount];
                lineCount++;
                return true;
            }
            else
            {
                nextLine = null;
                return false;
            }
        }
    }
}
