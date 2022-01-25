using System;

namespace KMA.ProgrammingInCSharp2022.Practice1Intro
{
    class Program
    {
        #region ValueType
        //static void Main(string[] args)
        //{
        //    MyMethodInt(out int myInt);
        //    Console.WriteLine(myInt);
        //}

        //public static void MyMethodInt(out int myInt)
        //{
        //    myInt = 6;
        //    Console.WriteLine(myInt);
        //}
        #endregion

        #region ReferenceType
        public class MyClass
        {
            public int MyProperty { get; set; }
        }

        static void Main(string[] args)
        {
            MyClass myObject = new MyClass();
            myObject.MyProperty = 5;
            MyMethodMyObject(ref myObject);
            Console.WriteLine(myObject.MyProperty);
        }

        public static void MyMethodMyObject(ref MyClass myObject)
        {
            myObject = new MyClass();
            myObject.MyProperty = 6;
            Console.WriteLine(myObject.MyProperty);
        }
        #endregion
    }
}
