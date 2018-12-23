using System;
using System.Collections.Generic;
using System.Text;

namespace PencilKata
{
    public class Pencil
    {
        public int MaxPointDurabilityValue { get; set; }
        public int RemainingDurability { get; set; }
        public int Length { get; set; }
        public int NewEraserDurabilityValue { get; set; }
        public int RemainingEraser { get; set; }

        public Pencil()
        {
            MaxPointDurabilityValue = 10;
            RemainingDurability = MaxPointDurabilityValue;
            Length = 5;
            NewEraserDurabilityValue = 10;
            RemainingEraser = NewEraserDurabilityValue;
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
                this.RemainingDurability = this.MaxPointDurabilityValue;
                isPencilSharpened = true;
            }
            return isPencilSharpened;
        }

        public string Erase(Paper paper, string textToEdit)
        {
            if (paper.Text.Contains(textToEdit))
            {
                StringBuilder sb = new StringBuilder(paper.Text);
                int numOfChars = textToEdit.Length;
                int startIndex = paper.Text.LastIndexOf(textToEdit) + numOfChars -1; //Editing starts at end of last match of textToEdit
                for (int i = 0; i < numOfChars; i++)
                {
                    if (RemainingEraser > 0)
                    {
                        sb[startIndex - i] = ' ';
                        this.RemainingEraser -= 1;
                    }
                }
                paper.Text = sb.ToString();
            }
            return paper.Text;
        }
    }
}
