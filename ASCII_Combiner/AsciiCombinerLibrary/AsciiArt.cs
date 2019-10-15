using System;
using System.Collections.Generic;
using System.Text;

namespace AsciiCombinerLibrary
{
    public class AsciiArt
    {
        public List<string> Lines { get; set; }
        public bool Valid { get; set; }

        public AsciiArt()
        {
            Valid = true;
            Lines = new List<string>();
        }

        public bool AddLine(string line)
        {
            if (Lines.Count > 0)
            {
                if (line.Length != Lines[0].Length)
                {
                    Valid = false;
                    return false;
                }
            }
            Lines.Add(line);
            return true;
        }

        public void Overwrite(AsciiArt art)
        {
            if(Lines.Count == 0)
            {
                Lines = art.Lines;
            }
            else
            {
                int lineCounter = 0;
                int columnCounter;
                foreach(string line in Lines)
                {
                    char[] charactersOld = line.ToCharArray();
                    char[] charactersNew = art.Lines[lineCounter].ToCharArray();

                    columnCounter = 0;
                    foreach (char character in charactersOld)
                    {
                        if(charactersNew[columnCounter] == ' ')
                        {
                            charactersNew[columnCounter] = character;
                        }
                        columnCounter++;
                    }

                    Lines[lineCounter] = charactersNew.ToString();
                    lineCounter++;
                }
            }
        }
    }
}
