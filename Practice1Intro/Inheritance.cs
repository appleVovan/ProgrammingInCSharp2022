using System;

namespace KMA.ProgrammingInCSharp2022.Practice1Intro
{
    public class BaseClass
    {
        public void NotVirtual()
        {
            Console.WriteLine("NotVirtual BaseClass");
        }

        public virtual void Virtual()
        {
            Console.WriteLine("Virtual BaseClass");
        }
    }


    public class DerivedClassOverride : BaseClass
    {

        public override void Virtual()
        {
            Console.WriteLine("Virtual DerivedClassOverride");
        }
    }

    public class DerivedClassHide : BaseClass
    {
        public void NotVirtual()
        {
            Console.WriteLine("NotVirtual DerivedClassHide");
        }

        public void Virtual()
        {
            Console.WriteLine("Virtual DerivedClassHide");
        }
    }

    public class DerivedClassHideNew : BaseClass
    {
        public new void NotVirtual()
        {
            Console.WriteLine("NotVirtual DerivedClassHideNew");
        }

        public new void Virtual()
        {
            Console.WriteLine("Virtual DerivedClassHideNew");
        }
    }
}
