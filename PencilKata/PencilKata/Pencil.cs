using System;
using System.Collections.Generic;
using System.Text;

namespace PencilKata
{
    public class Pencil
    {
        public string Write(string textToWrite, Paper paper)
        {
            paper.Text += textToWrite;
            return paper.Text;
        }

        public int CharacterCount(string text)
        {
            int characterCount = 0;
            for(int i =0; i <text.Length; i++)
            {
                if(text[i] != ' ')
                {
                    characterCount++;
                }
            }
            return characterCount;
        }
    }
}
