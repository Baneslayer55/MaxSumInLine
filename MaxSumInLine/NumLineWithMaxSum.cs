using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;

namespace MaxSumInLine
{
    public class NumLineWithMaxSum
    {
        private ILinesSource importedFile;

        private List<string> invalidStrings = new List<string>();

        private int numLinewWithMaxSum = 0;

        public int NumLineWithMaxSumValue => numLinewWithMaxSum;

        public List<string> InvalidStrings => invalidStrings;

        public NumLineWithMaxSum(ILinesSource importedFile)
        {
            this.importedFile = importedFile;
            SetParameters();
        }
        
        private bool TryGetSumInLane(string inputString, out double sum) 
        {
            if (inputString.Length > 0)
            {
                string[] tempArray = inputString.Split(new char[] { ',' });
                sum = 0;
                foreach (string str in tempArray)
                {                    
                    if (Double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out double curValue))
                    {
                        sum += curValue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                sum = 0;
                return false;
            }
        }
        
        private void SetParameters()
        {
            Dictionary<int, double> validStrings = new Dictionary<int, double>();
            
            int count = 0;
            
            while (importedFile.TryGetNextLine(out string tempString))
            {
                count++;

                if (TryGetSumInLane(tempString, out double curValue))
                {
                    validStrings.Add(count, curValue);
                }
                else
                {
                    invalidStrings.Add(tempString);
                }
            }
            if (validStrings.Count > 0)
            {
                numLinewWithMaxSum = validStrings.Aggregate((max, cur) => max.Value > cur.Value ? max : cur).Key;
            }
        }
    }
}
