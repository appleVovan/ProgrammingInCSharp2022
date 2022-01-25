namespace KMA.ProgrammingInCSharp2022.Practice1Intro
{
    partial class Dog
    {
        private int age;

        public int Age 
        { 
            get 
            {
                return age;
            }
            set
            { 
                age = value;
            } 
        }

        public string Name { get; set; }

        public string Identifier
        {
            get
            {
                return $"{Name} {Age}";
            }
        }


        public void MyMethod()
        {
            int val1 = Age;
            Age = 5;
        }
    }
}
