// See https://aka.ms/new-console-template for more information

namespace Birthday
{

    public partial class Program
    {
        static void Main(string[] args)
        {
            PeopleDatabase pdb = new PeopleDatabase("peopleDB.txt");

            Console.WriteLine("Hello, World!");
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
            Console.WriteLine(name + surname);
        }
    }
    class PeopleDatabase
    {
        public Person[] people;
        public int peopleSize;
        public PeopleDatabase(string file)
        {
            peopleSize = 0;
            people = new Person[0];
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
                            Console.WriteLine(line);
                            string[] parts = line.Split(';');
                            string[] fullName = parts[0].Split(' ');
                            Person p = new Person(fullName[0], fullName[1], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                            // addPerson(p);
                            Console.WriteLine(fullName[0]);
                            Console.WriteLine(fullName[1]);
                            Console.WriteLine(parts[1]);
                            Console.WriteLine(parts[2]);
                            Console.WriteLine(parts[3]);
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
        public void addPerson(Person person)
        {
            people[peopleSize] = person;
            peopleSize++;
        }
    }
}
