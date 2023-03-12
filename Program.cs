namespace Birthday
{

    public partial class Program
    {
        static void Main(string[] args)
        {
            PeopleDatabase pdb = new PeopleDatabase("peopleDB.txt");
            pdb.printAll();
        }
    }
    class Person
    {
        public string name;
        public string surname;
        public int year;
        public int month;
        public int day;
        public Person(string name, string surname, int year, int month, int day)
        {
            this.name = name;
            this.surname = surname;
            this.year = year;
            this.month = month;
            this.day = day;
        }
        public void print()
        {
            Console.WriteLine(name + " " + surname + ": " + year + "/" + month + "/" + day);
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
                            Person p = new Person(fullName[0], fullName[1], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
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
    }
}
