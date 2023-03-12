namespace Birthday
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            PeopleDatabase pdb = new PeopleDatabase("peopleDB.txt");
            // pdb.printAll();
            // Console.WriteLine();
            // pdb.sort();
            pdb.printAll();
            Console.WriteLine();
            string queryName = "Mark Davis";
            Console.WriteLine($"Age of {queryName}: {pdb.search(queryName).age()}");
            Console.WriteLine($"Youngest: {pdb.youngest()}");
            Console.WriteLine($"Oldest: {pdb.oldest()}");
            Console.WriteLine();
            Console.WriteLine("Upcoming birthdays: ");
            pdb.upcomingBirthdays();
        }
    }
}
