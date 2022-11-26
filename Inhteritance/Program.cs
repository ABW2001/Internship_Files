using System;

namespace Inhteritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Intern intern = new Intern("Andre");
            intern.display();
        }


    }

    class Mentor //base class
    {
        public string name = "Wael";
    }

    class Intern : Mentor // derived class
    {
        public string internName;

        public Intern (string internName)
        {
            this.internName = internName;
        }

        public void display() 
        {
            Console.WriteLine(internName + " is mentored by " + name);
        }
    }
}
