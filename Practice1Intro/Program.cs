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

        //static void Main(string[] args)
        //{
        //    MyClass myObject = new MyClass();
        //    myObject.MyProperty = 5;
        //    MyMethodMyObject(ref myObject);
        //    Console.WriteLine(myObject.MyProperty);
        //}

        //public static void MyMethodMyObject(ref MyClass myObject)
        //{
        //    myObject = new MyClass();
        //    myObject.MyProperty = 6;
        //    Console.WriteLine(myObject.MyProperty);
        //}
        #endregion

        static void Main(string[] args)
        {
            BaseClass baseObject = new BaseClass();
            DerivedClassOverride derivedOverrideObject = new DerivedClassOverride();
            DerivedClassHide derivedHideObject = new DerivedClassHide();
            DerivedClassHideNew derivedHideNewObject = new DerivedClassHideNew();

            Console.WriteLine("Call for baseObject {0}");
            baseObject.NotVirtual();
            baseObject.Virtual();
            Console.WriteLine("Call for derivedVirtualObject {0}");
            derivedOverrideObject.NotVirtual();
            derivedOverrideObject.Virtual();
            Console.WriteLine("Call for derivedObject {0}");
            derivedHideObject.NotVirtual();
            derivedHideObject.Virtual();
            Console.WriteLine("Call for derivedNewObject {0}");
            derivedHideNewObject.NotVirtual();
            derivedHideNewObject.Virtual();
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Call for baseObject {0}");
            baseObject.NotVirtual();
            baseObject.Virtual();
            Console.WriteLine("Call for casted derivedVirtualObject {0}");
            ((BaseClass)derivedOverrideObject).NotVirtual();
            ((BaseClass)derivedOverrideObject).Virtual();
            Console.WriteLine("Call for casted derivedObject {0}");
            ((BaseClass)derivedHideObject).NotVirtual();
            ((BaseClass)derivedHideObject).Virtual();
            Console.WriteLine("Call for casted derivedNewObject {0}");
            ((BaseClass)derivedHideNewObject).NotVirtual();
            ((BaseClass)derivedHideNewObject).Virtual();
            Console.ReadKey();
        }
    }
}
