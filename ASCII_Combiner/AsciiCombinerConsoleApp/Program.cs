using AsciiCombinerLibrary;
using System;
using System.Collections.Generic;
using System.IO;

namespace AsciiCombinerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                Console.Error.WriteLine("At least two text files have to be specified.");
                return;
            }

            List<string> asciiTextFiles = new List<string>();

            foreach(string filename in args)
            {
                asciiTextFiles.Add(ReadFile(filename));
            }

            AsciiCombiner combiner = new AsciiCombiner();
            var asciiArts = combiner.BuildAsciiArtList(asciiTextFiles);
            var asciiArtResult = combiner.CombineAsciiArts(asciiArts);

            bool printed = false;
            foreach(string line in asciiArtResult.Lines)
            {
                printed = true;
                Console.WriteLine(line);
            }

            if (!printed)
            {
                Console.Error.WriteLine("Files do not contain the same number of lines or columns.");
            }
        }

        public static string ReadFile(string filename)
        {
            string asciiText;
            try
            {
                // Read the file
                asciiText = File.ReadAllText(filename);
            }
            catch (FileNotFoundException ex)
            {
                Console.Error.WriteLine("The file" + filename + " could not be found.");
                throw;
            }

            return asciiText;
        }
    }
}
