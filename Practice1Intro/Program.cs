using System;

namespace KMA.ProgrammingInCSharp2022.Practice1Intro
{
    class Program
    {
        #region ValueType
        static void Main(string[] args)
        {
            int myInt;
            MyMethodInt(out myInt);
            Console.WriteLine(myInt);
        }

        public static void MyMethodInt(out int myInt)
        {
            myInt = 6;
            Console.WriteLine(myInt);
        }
        #endregion
    }
}
