namespace Birthday
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            PeopleDatabase pdb = new PeopleDatabase();
            sampleData(ref pdb);
            bool run = true;
            while (run)
            {
                switch (options())
                {
                    case 'a':
                        PeopleController.printAll(ref pdb);
                        break;
                    case 'b':
                        PeopleController.searchFullName(ref pdb);
                        break;
                    case 'c':
                        PeopleController.searchName(ref pdb);
                        break;
                    case 'd':
                        PeopleController.searchSurname(ref pdb);
                        break;
                    case 'e':
                        PeopleController.youngest(ref pdb);
                        break;
                    case 'f':
                        PeopleController.oldest(ref pdb);
                        break;
                    case 'g':
                        PeopleController.upcomingBirthdays(ref pdb);
                        break;
                    case 'h':
                        PeopleController.addPerson(ref pdb);
                        break;
                    case 'i':
                        PeopleController.writeToFile(ref pdb);
                        break;
                    case 'j':
                        PeopleController.sortByName(ref pdb);
                        break;
                    case 'k':
                        PeopleController.sortBySurname(ref pdb);
                        break;
                    case 'l':
                        PeopleController.sortByBirthday(ref pdb);
                        break;
                    case 'm':
                        PeopleController.loadDatabase(ref pdb);
                        break;
                    case 'q':
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Wrong option");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static char options()
        {
            Console.WriteLine("Birthday");
            Console.WriteLine("Options: ");
            Console.WriteLine("'a': Print all");
            Console.WriteLine("'b': Search by name and surname");
            Console.WriteLine("'c': Search by name");
            Console.WriteLine("'d': Search by surname");
            Console.WriteLine("'e': Youngest");
            Console.WriteLine("'f': Oldest");
            Console.WriteLine("'g': Upcoming birthdays in this month");
            Console.WriteLine("'h': Add person");
            Console.WriteLine("'i': Write to file");
            Console.WriteLine("'j': Sort by name");
            Console.WriteLine("'k': Sort by surname");
            Console.WriteLine("'l': Sort by birthday");
            Console.WriteLine("'m': Load database from file");
            Console.WriteLine("'q': quit");
            char selectedOption = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            Console.WriteLine();
            return selectedOption;
        }
        static void sampleData(ref PeopleDatabase pdb) {
            pdb.addPerson("John", "Smith", 1987, 3, 25);
            pdb.addPerson("Peter", "Johnson", 1994, 7, 12);
            pdb.addPerson("Jenny", "King", 2002, 12, 17);
            pdb.addPerson("Adam", "Lee", 1990, 5, 6);
            pdb.addPerson("Sarah", "Miller", 1985, 9, 2);
            pdb.addPerson("David", "Davis", 2001, 2, 8);
            pdb.addPerson("Emily", "Chen", 1998, 11, 23);
            pdb.addPerson("Michael", "Thompson", 1979, 4, 14);
            pdb.addPerson("Grace", "Kim", 1992, 8, 1);
            pdb.addPerson("Benjamin", "Brown", 1983, 1, 10);
            pdb.addPerson("Samantha", "Lee", 1997, 6, 21);
            pdb.addPerson("Erica", "Green", 2000, 10, 4);
            pdb.addPerson("Matthew", "Taylor", 1989, 2, 16);
            pdb.addPerson("Mark", "Davis", 1978, 7, 19);
            pdb.addPerson("Linda", "Rodriguez", 1991, 4, 2);
            pdb.addPerson("Robert", "Parker", 2005, 9, 13);
            pdb.addPerson("Anna", "Mitchell", 1984, 12, 8);
            pdb.addPerson("Joshua", "Turner", 1999, 3, 27);
            pdb.addPerson("Olivia", "Hernandez", 2003, 5, 21);
            pdb.addPerson("William", "Johnson", 1945, 8, 12);
            pdb.addPerson("Margaret", "Davis", 1956, 2, 24);
            pdb.addPerson("Charles", "Wilson", 1968, 11, 7);
            pdb.addPerson("Helen", "Brown", 1973, 7, 15);
            pdb.addPerson("Robert", "Thompson", 1981, 4, 3);
            pdb.addPerson("Dorothy", "Garcia", 1987, 10, 22);
            pdb.addPerson("George", "Hernandez", 1995, 1, 18);
            pdb.addPerson("Elizabeth", "Lopez", 2000, 9, 5);
            pdb.addPerson("Edward", "Rodriguez", 2008, 6, 29);
            pdb.addPerson("David", "Smith", 1940, 11, 16);
            pdb.addPerson("Ruth", "Brown", 1952, 5, 21);
            pdb.addPerson("James", "Lee", 1963, 9, 1);
            pdb.addPerson("Dorothy", "Thompson", 1971, 12, 7);
            pdb.addPerson("Michael", "King", 1980, 8, 18);
            pdb.addPerson("Mary", "Garcia", 1993, 1, 31);
            pdb.addPerson("Richard", "Mitchell", 1998, 7, 2);
            pdb.addPerson("Barbara", "Hernandez", 2004, 4, 8);
            pdb.addPerson("Frank", "Davis", 1939, 12, 3);
        }
    }
}
