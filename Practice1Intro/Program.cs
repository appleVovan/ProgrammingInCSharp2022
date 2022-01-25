using System;

namespace KMA.ProgrammingInCSharp2022.Practice1Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            int myInt = 5;
            MyMethodInt(myInt);
            Console.WriteLine(myInt);
        }

        public static void MyMethodInt(int myInt)
        {
            myInt = 6;
            Console.WriteLine(myInt);
        }
    }
}
