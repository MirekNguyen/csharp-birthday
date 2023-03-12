namespace Birthday
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            PeopleDatabase pdb = new PeopleDatabase("peopleDB.txt");
            // pdb.printAll();
            // Console.WriteLine();
            // pdb.sort();
            while (run)
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
                Console.WriteLine("'q': quit");
                char c;
                c = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                Console.WriteLine();
                string queryName;
                switch (c)
                {
                    case 'a':
                        pdb.printAll();
                        break;
                    case 'b':
                        Console.WriteLine("Search by name and surname (case insensitive)");
                        Console.Write("Insert query: e.g. \"Mark Davis\": ");
                        queryName = Console.ReadLine() ?? "";
                        Person? p = pdb.search(queryName);
                        Console.WriteLine(p != null ? $"{p}" : "Person not found");
                        break;
                    case 'c':
                        Console.WriteLine("Search by name (case insensitive)");
                        Console.Write("Insert query: e.g. \"Mark\": ");
                        queryName = Console.ReadLine() ?? "";
                        List<Person> plist = pdb.searchByName(queryName);
                        Person.printList(plist);
                        break;
                    case 'd':
                        Console.WriteLine("Search by surname (case insensitive)");
                        Console.Write("Insert query: e.g. \"Davis\": ");
                        queryName = Console.ReadLine() ?? "";
                        List<Person> plistSurname = pdb.searchBySurname(queryName);
                        Person.printList(plistSurname);
                        break;
                    case 'e':
                        Console.WriteLine($"Youngest: {pdb.youngest()}");
                        break;
                    case 'f':
                        Console.WriteLine($"Oldest: {pdb.oldest()}");
                        break;
                    case 'g':
                        Console.WriteLine("Upcoming birthdays in this month: ");
                        Console.WriteLine();
                        Person.printList(pdb.upcomingBirthdays());
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
    }
}
