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
    }
}
