namespace Birthday
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public Person(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }
        public void print()
        {
        }
        public int age()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Birthday.Year;
            if (Birthday > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
        public override string ToString()
        {
            return $"{Name} {Surname}: " + Birthday.ToString("yyyy-MM-dd");
        }
    }
}
