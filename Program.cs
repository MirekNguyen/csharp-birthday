namespace Birthday
{

    public partial class Program
    {
        static void Main(string[] args)
        {
            PeopleDatabase pdb = new PeopleDatabase("peopleDB.txt");
            pdb.printAll();
            pdb.people[0].age();
            Console.WriteLine();
            pdb.sort();
            pdb.printAll();
            Console.WriteLine(pdb.search("Mark Davis").age());
        }
    }
    class Person
    {
        public string name;
        public string surname;
        public DateTime birthday;
        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }
        public void print()
        {
            Console.WriteLine($"{name} {surname}: " + birthday.ToString("yyyy-MM-dd"));
        }
        public int age()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthday.Year;
            if (birthday > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
    class PeopleDatabase
    {
        public List<Person> people;
        public PeopleDatabase(string file)
        {
            people = new List<Person>();
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(file))
                {
                    while (sr.Peek() >= 0)
                    {
                        string? line = sr.ReadLine();
                        if (line != null)
                        {
                            // Console.WriteLine(line);
                            string[] parts = line.Split(';');
                            string[] fullName = parts[0].Split(' ');
                            DateTime birthday = new DateTime(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                            Person p = new Person(fullName[0], fullName[1], birthday);
                            people.Add(p);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }
        public void printAll()
        {
            foreach (Person person in people)
            {
                person.print();
            }
        }
        public void sort()
        {

            people = people.OrderBy(p => p.birthday).ToList();
        }
        public Person search(string searchQuery)
        {
            return people.FirstOrDefault(p => (p.name + " " + p.surname).Equals(searchQuery, StringComparison.OrdinalIgnoreCase));
        }
    }
}
