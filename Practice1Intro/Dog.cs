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

        public int Get_Age()
        {
            return age;
        }

        public void Set_Age(int val)
        {
            this.age = val;
        }
    }
}
