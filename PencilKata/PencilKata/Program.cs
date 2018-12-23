using System;

namespace PencilKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Pencil pencil = new Pencil();
            Paper paper = new Paper();
            paper.Text = "text text";
            pencil.Edit(paper, "text");
        }
    }
}
