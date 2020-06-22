using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumInLine
{
    public interface ILinesSource
    {
        bool TryGetNextLine(out string nextLine);
    }
}
