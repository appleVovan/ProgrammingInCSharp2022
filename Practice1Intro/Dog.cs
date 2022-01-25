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


        public void MyMethod()
        {
            int val1 = Age;
            Age = 5;
        }
    }
}
