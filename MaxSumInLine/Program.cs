using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Linq;

namespace MaxSumInLine
{
    class Program
    {
        static void Main(string[] args)
        {            
            while (true)
            {
                string filePath;

                if (args.Length > 0)
                {
                    filePath = args[0];
                }
                else
                {
                    Console.WriteLine("Please, enter file's path:");
                    filePath = Console.ReadLine();
                }                

                using (FileLinesSource importedFile = new FileLinesSource(filePath))
                {
                    try
                    {
                        NumLineWithMaxSum maxSum = new NumLineWithMaxSum(importedFile);

                        if (maxSum.NumLineWithMaxSumValue > 0)
                        {
                            Console.WriteLine($"In your file line {maxSum.NumLineWithMaxSumValue} has max value!\n");
                        }
                        else
                        {
                            Console.WriteLine("There are no valid data in input file!\n");
                        }

                        if (maxSum.InvalidStrings.Count > 0)
                        {
                            Console.WriteLine("Invalid strings in your file:");
                            foreach (string str in maxSum.InvalidStrings)
                            {
                                Console.WriteLine(str);
                            }
                        }
                        else if (maxSum.NumLineWithMaxSumValue == 0 && maxSum.InvalidStrings.Count == 0)
                        {
                            Console.WriteLine("Hey! Рath leads to empty file. Check it!");
                        }
                        else
                        {
                            Console.WriteLine("Well done! All datas in your file are valid! Grats!");
                        }
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                if (args.Length > 0)
                {
                    Console.WriteLine("The program is finished.\nPlease, press any key to close the program.");
                    Console.ReadLine();
                    break;
                }
            }            
        }
    }
}
