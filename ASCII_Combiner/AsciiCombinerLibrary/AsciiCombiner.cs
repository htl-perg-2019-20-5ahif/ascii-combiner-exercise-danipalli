using System;
using System.Collections.Generic;

namespace AsciiCombinerLibrary
{
    public class AsciiCombiner
    {
        public IEnumerable<AsciiArt> BuildAsciiArtList(IEnumerable<string> asciiTextFiles)
        {
            List<AsciiArt> asciiArts = new List<AsciiArt>();

            foreach (string asciiTextFile in asciiTextFiles)
            {
                asciiArts.Add(CreateAsciiArt(asciiTextFile.Replace("\r", "").Split('\n')));
            }

            if (CheckAsciiArtLines(asciiArts))
            {
                return asciiArts;
            }

            return default;
        }

        public AsciiArt CombineAsciiArts(IEnumerable<AsciiArt> asciiArts)
        {
            AsciiArt result = new AsciiArt();

            foreach(AsciiArt art in asciiArts)
            {
                result.Overwrite(art);
            }

            return result;
        }



        private static AsciiArt CreateAsciiArt(string[] lines)
        {
            AsciiArt asciiArt = new AsciiArt();

            foreach (string line in lines)
            {
                asciiArt.AddLine(line);
            }

            return asciiArt;
        }

        private static bool CheckAsciiArtLines(List<AsciiArt> asciiArts)
        {
            int lines = asciiArts[0].Lines.Count;

            foreach(AsciiArt art in asciiArts)
            {
                if (!art.Valid)
                {
                    return false;
                }
                if(art.Lines.Count != lines)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
