using System;

namespace PencilKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Paper paper = new Paper();
            Pencil pencil = new Pencil();
            
            Console.WriteLine(paper.Text);
            Console.ReadLine();
            
        }
    }
}
