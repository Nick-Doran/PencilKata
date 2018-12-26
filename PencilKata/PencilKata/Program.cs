using System;

namespace PencilKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Paper paper = new Paper();
            Pencil pencil = new Pencil();
            paper.Text = "This is a test string";
            pencil.Edit(paper, "test", "\r\n");
            Console.WriteLine(paper.Text);
            Console.ReadLine();
            
        }
    }
}
