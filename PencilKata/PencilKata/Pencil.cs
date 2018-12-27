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

        public string Write(string textToWrite, Paper paper)
        {
            for (int i = 0; i < textToWrite.Length; i++)
            {
                if (char.IsWhiteSpace(textToWrite[i]))
                {
                    paper.Text += ' ';
                    continue;
                }
                else if (textToWrite[i] == '\\' && textToWrite.Length > i + 1)
                {
                    if (textToWrite.Substring(i, 2) == "\\r" || textToWrite.Substring(i, 2) == "\\n")
                    {
                        i += 1;
                        continue;
                    }
                }
                if (char.IsUpper(textToWrite[i]))
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

        public string Erase(Paper paper, string textToErase, out int startIndex)
        {
            startIndex = -1;
            if (paper.Text.Contains(textToErase))
            {
                StringBuilder sb = new StringBuilder(paper.Text);
                int numOfChars = textToErase.Length;
                startIndex = paper.Text.LastIndexOf(textToErase) + numOfChars - 1; //Editing starts at end of most recent match of textToErase
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

        public string Edit(Paper paper, string textToErase, string replacementText)
        {
            int startIndex = -1;
            if (paper.Text.Contains(textToErase))
            {
                StringBuilder sb = new StringBuilder(paper.Text);
                int numOfChars = textToErase.Length;
                startIndex = paper.Text.LastIndexOf(textToErase);
                int endOfStringToErase = startIndex + numOfChars - 1; //Editing starts at end of most recent match of textToErase
                for (int i = 0; i < numOfChars; i++)
                {
                    if (RemainingEraser > 0)
                    {
                        sb[endOfStringToErase - i] = ' ';
                        this.RemainingEraser -= 1;
                    }
                }
                paper.Text = sb.ToString();
            }
            if (startIndex >= 0) //Checks if paper.Text contains textToErase
            {
                for (int i = 0; i < replacementText.Length; i++)
                {
                    if (paper.Text[startIndex + i] == ' ' && char.IsUpper(replacementText[i]) && this.RemainingDurability >= 2)
                    {
                        paper.Text = paper.Text.Insert(startIndex + i, replacementText.Substring(i, 1));
                        paper.Text = paper.Text.Remove(startIndex + i + 1, 1);
                    }
                    else if (paper.Text[startIndex + i] == ' ' && char.IsLower(replacementText[i]) && this.RemainingDurability >= 1)
                    {
                            paper.Text = paper.Text.Insert(startIndex + i, replacementText.Substring(i, 1));
                            paper.Text = paper.Text.Remove(startIndex + i + 1, 1);
                    }
                    else if (paper.Text[startIndex + i] != ' ' && this.RemainingDurability >=1)
                    {
                        paper.Text = paper.Text.Insert(startIndex + i, "@");
                        paper.Text = paper.Text.Remove(startIndex + i + 1, 1);
                    }
                }
            }
            return paper.Text;
        }
    }
}
