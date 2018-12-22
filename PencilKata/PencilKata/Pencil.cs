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

    }
}
