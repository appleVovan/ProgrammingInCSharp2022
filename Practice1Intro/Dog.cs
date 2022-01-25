namespace KMA.ProgrammingInCSharp2022.Practice1Intro
{
    public enum DogType
    {
        Poodle,
        Labrador,
        Labradoodle
    }

    partial class Dog
    {
        private int age;
        private DogType dogType;

        public int Age 
        { 
            get 
            {
                return age;
            }
            set
            {
                if (value>0)
                    age = value;
            } 
        }
        public DogType DogType
        {
            get
            {
                return dogType;
            }
            set
            {
                dogType = value;
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



        private void Foo()
        {

        }

        internal void Bar()
        {

        }

        protected void Gas()
        {

        }

        public void Talk(string value)
        {

        }

        public void Talk(int times, string value = "woof", bool sit = false)
        {

        }


        public void MyMethod()
        {
            int val1 = Age;
            Age = 5;

            dogType = DogType.Labrador;
            switch (dogType)
            {
                case DogType.Poodle:
                    break;
                case DogType.Labrador:
                    break;
                case DogType.Labradoodle:
                    break;
                default:
                    break;
            }

            Talk("woof");
            Talk(3, "bark");
            Talk(3, sit:true);
        }
    }
}
