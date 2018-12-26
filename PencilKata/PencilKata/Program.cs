using System;

namespace PencilKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Paper paper = new Paper();
            Pencil pencil = new Pencil();
            paper.Text = "test oneone test";
            pencil.Erase(paper, "one", out int startIndex);
            
        }
    }
}
