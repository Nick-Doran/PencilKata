using System;
using System.Collections.Generic;
using System.Text;

namespace PencilKata
{
    public class Pencil
    {
        public Pencil()
        {
            RemainingDurability = 10;
        }
        public int RemainingDurability { get; set; }

        public string Write(string textToWrite, Paper paper, out int characterCount)
        {
            characterCount = CharacterCount(textToWrite);
            this.RemainingDurability -= characterCount;
            paper.Text += textToWrite;
            return paper.Text;
        }

        public int CharacterCount(string text)
        {
            int characterCount = 0;
            for(int i =0; i <text.Length; i++)
            {
                if(text[i] == ' ')
                {
                    continue;
                }
                else if (text[i]== '\\')
                {
                    if (text.Substring(i, 4)== "\\r\\n")
                    {
                        i += 3;
                        continue;
                    }
                }
                else if (char.IsUpper(text[i]))
                {
                    characterCount += 2;
                    continue;
                }
                else
                {
                    characterCount++;
                }
            }
            return characterCount;
        }
    }
}
