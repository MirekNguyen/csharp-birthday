namespace Birthday 
{
    class PeopleController {
        public static void printAll(ref PeopleDatabase pdb) {
            pdb.printAll();
        }
        public static void searchFullName(ref PeopleDatabase pdb) {
            Console.WriteLine("Search by name and surname (case insensitive)");
            Console.Write("Insert query: e.g. \"Mark Davis\": ");
            List<Person> p = pdb.search(Console.ReadLine() ?? "");
            Person.printList(p);
        }
        public static void searchName(ref PeopleDatabase pdb) {
            Console.WriteLine("Search by name (case insensitive)");
            Console.Write("Insert query: e.g. \"Mark\": ");
            List<Person> plist = pdb.searchByName(Console.ReadLine() ?? "");
            Person.printList(plist);
        }
        public static void searchSurname(ref PeopleDatabase pdb) {
            Console.WriteLine("Search by surname (case insensitive)");
            Console.Write("Insert query: e.g. \"Davis\": ");
            List<Person> plistSurname = pdb.searchBySurname(Console.ReadLine() ?? "");
            Person.printList(plistSurname);
        }
        public static void youngest(ref PeopleDatabase pdb) {
            Console.WriteLine($"Youngest: {pdb.youngest()}");
        }
        public static void oldest(ref PeopleDatabase pdb) {
            Console.WriteLine($"Oldest: {pdb.oldest()}");
        }
        public static void upcomingBirthdays(ref PeopleDatabase pdb) {
            Console.WriteLine("Upcoming birthdays in this month: ");
            Console.WriteLine();
            Person.printList(pdb.upcomingBirthdays());
        }
        public static void addPerson(ref PeopleDatabase pdb) {
            Console.WriteLine("Add person");
            Console.WriteLine("Syntax e.g.: John Smith; 1987; 3; 25");
            string input = Console.ReadLine() ?? "";
            Person? newPerson = PeopleDatabase.stringToPerson(input);
            // if stringToPerson method success
            if (newPerson != null)
            {
                Console.WriteLine("Success, added 1 person");
                pdb.addPerson(newPerson);
            }
            else
            {
                Console.WriteLine("Invalid string format");
            }
        }
        public static void writeToFile(ref PeopleDatabase pdb) {
            Console.WriteLine("Relative path e.g.: sample.txt");
            Console.WriteLine("Absolute path Linux/Mac e.g.: /home/user_name/Desktop/sample.txt");
            Console.WriteLine("Absolute path Windows e.g.: C:\\Users\\user_name\\Desktop\\sample.txt");
            Console.WriteLine();
            Console.Write("Please enter a file path: ");
            string path = Console.ReadLine() ?? "";
            if (path == "")
            {
                return;
            }
            // iterating through each person and trying to write it to a file
            try {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (Person person in pdb.people)
                    {
                        writer.WriteLine($"{person.Name} {person.Surname}; {person.Birthday.Year}; {person.Birthday.Month}; {person.Birthday.Day}");
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine("Error while writing to file: " + e.Message);
            }
            if (System.IO.File.Exists(path))
            {
                string fullPath = System.IO.Path.GetFullPath(path);
                Console.WriteLine($"File was written to {fullPath}");
            }
        }
        public static void sortByName(ref PeopleDatabase pdb) {
            pdb.sortByName();
        }
        public static void sortBySurname(ref PeopleDatabase pdb) {
            pdb.sortBySurname();
        }
        public static void sortByBirthday(ref PeopleDatabase pdb) {
            pdb.sortByBirthday();
        }
        public static void loadDatabase(ref PeopleDatabase pdb) {
            Console.WriteLine("Relative path e.g.: sampleDB.txt");
            Console.WriteLine("Absolute path Linux/Mac e.g.: /home/user_name/Desktop/sampleDB.txt");
            Console.WriteLine("Absolute path Windows e.g.: C:\\Users\\user_name\\Desktop\\sampleDB.txt");
            Console.WriteLine();
            Console.Write("Please enter a file path: ");
            string dbPath = Console.ReadLine() ?? "";
            if (dbPath == "") 
            {
                return;
            }
            // check if path exists
            if (System.IO.File.Exists(dbPath))
            {
                string fullPath = System.IO.Path.GetFullPath(dbPath);
                Console.WriteLine($"Loading from {fullPath}");
                pdb.loadDatabase(dbPath);
            }
            else 
            {
                string fullPath = System.IO.Path.GetFullPath(dbPath);
                Console.WriteLine($"File doesn't exist: {fullPath}");
            }
        }
    }
}
