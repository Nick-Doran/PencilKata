using System;
using System.Collections.Generic;
using System.Text;

namespace PencilKata
{
    public class Pencil
    {
        public int MaxDurability { get; set; }
        public int RemainingDurability { get; set; }
        public int Length { get; set; }

        public Pencil()
        {
            MaxDurability = 10;
            RemainingDurability = MaxDurability;
            Length = 5;
        }

        public string Write(string textToWrite, Paper paper, out int remainingDurability)
        {
            for (int i = 0; i < textToWrite.Length; i++)
            {
                if (textToWrite[i] == ' ')
                {
                    paper.Text += ' ';
                    continue;
                }
                else if (textToWrite[i] == '\\')
                {
                    if (textToWrite.Substring(i, 4) == "\\r\\n")
                    {
                        i += 3;
                        continue;
                    }
                }
                else if (char.IsUpper(textToWrite[i]))
                {
                    if (RemainingDurability >= 2)
                    {
                        paper.Text += textToWrite[i];
                        this.RemainingDurability -= 2;
                        continue;
                    }
                    else
                    {
                        paper.Text += ' ';
                        this.RemainingDurability = 0;
                        continue;
                    }
                }
                else
                {
                    if (RemainingDurability >= 1)
                    {
                        paper.Text += textToWrite[i];
                        this.RemainingDurability -= 1;
                        continue;
                    }
                    else
                    {
                        paper.Text += ' ';
                        continue;

                    }
                }
            }
            remainingDurability = this.RemainingDurability;
            return paper.Text;
        }

        public bool Sharpen()
        {
            bool isPencilSharpened = false;
            if (this.Length >= 1)
            {
                this.Length -= 1;
                this.RemainingDurability = this.MaxDurability;
                isPencilSharpened = true;
            }
            return isPencilSharpened;
        }

        public string Edit(Paper paper, string textToEdit)
        {
            if (paper.Text.Contains(textToEdit))
            {
                StringBuilder sb = new StringBuilder(paper.Text);
                int numOfChars = textToEdit.Length;
                int startIndex = paper.Text.LastIndexOf(textToEdit);
                for (int i = 0; i < numOfChars; i++)
                {
                   sb[startIndex+i] = ' ';
                }
                paper.Text = sb.ToString();
            }
            return paper.Text;
        }
    }
}
