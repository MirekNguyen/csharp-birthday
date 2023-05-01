﻿namespace Birthday
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            PeopleDatabase pdb = new PeopleDatabase("peopleDB.txt");
            bool run = true;
            while (run)
            {
                switch (options())
                {
                    case 'a':
                        pdb.printAll();
                        break;
                    case 'b':
                        Console.WriteLine("Search by name and surname (case insensitive)");
                        Console.Write("Insert query: e.g. \"Mark Davis\": ");
                        List<Person> p = pdb.search(Console.ReadLine() ?? "");
                        Person.printList(p);
                        break;
                    case 'c':
                        Console.WriteLine("Search by name (case insensitive)");
                        Console.Write("Insert query: e.g. \"Mark\": ");
                        List<Person> plist = pdb.searchByName(Console.ReadLine() ?? "");
                        Person.printList(plist);
                        break;
                    case 'd':
                        Console.WriteLine("Search by surname (case insensitive)");
                        Console.Write("Insert query: e.g. \"Davis\": ");
                        List<Person> plistSurname = pdb.searchBySurname(Console.ReadLine() ?? "");
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
                    case 'h':
                        Console.WriteLine("Add person");
                        Console.WriteLine("Syntax e.g.: John Smith; 1987; 3; 25");
                        string input = Console.ReadLine() ?? "";
                        Person? newPerson = PeopleDatabase.stringToPerson(input);
                        if (newPerson != null)
                        {
                            Console.WriteLine("Success, added 1 person");
                            pdb.addPerson(newPerson);
                        }
                        else
                        {
                            Console.WriteLine("Invalid string format");
                        }
                        break;
                    case 'i':
                        Console.WriteLine("Relative path e.g.: sample.txt");
                        Console.WriteLine("Absolute path Linux/Mac e.g.: /home/user_name/Desktop/sample.txt");
                        Console.WriteLine("Absolute path Windows e.g.: C:\\Users\\user_name\\Desktop\\sample.txt");
                        Console.WriteLine();
                        Console.Write("Please enter a file path: ");
                        string path = Console.ReadLine() ?? "";
                        if (path == "")
                        {
                            break;
                        }
                        try {
                            using (StreamWriter writer = new StreamWriter(path))
                            {
                                foreach (Person person in pdb.people)
                                {
                                    writer.WriteLine($"{person.Name} {person.Surname}; {person.Birthday.Year}; {person.Birthday.Month}; {person.Birthday.Day}");
                                }
                            }
                            // System.IO.File.WriteAllText(path, "Hello, world!");
                        }
                        catch (Exception e) {
                            Console.WriteLine("Error while writing to file: " + e.Message);
                        }
                        if (System.IO.File.Exists(path))
                        {
                            string fullPath = System.IO.Path.GetFullPath(path);
                            Console.WriteLine($"File was written to {fullPath}");
                        }
                        break;
                    case 'j':
                        pdb.sortByName();
                        break;
                    case 'k':
                        pdb.sortByBirthday();
                        break;
                    case 'l':
                        string dbPath = Console.ReadLine() ?? "";
                        if (dbPath == "") 
                        {
                            break;
                        }
                        if (System.IO.File.Exists(dbPath))
                        {
                            PeopleDatabase pdbNew = new PeopleDatabase(dbPath);
                            pdb = pdbNew;
                        }
                        else 
                        {
                            Console.WriteLine($"Invalid path: {dbPath}");
                        }
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
            Console.WriteLine("'k': Sort by birthday");
            Console.WriteLine("'q': quit");
            char selectedOption = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            Console.WriteLine();
            return selectedOption;
        }
    }
}
