namespace Birthday
{
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
                Console.WriteLine(person);
            }
        }
        public void sortByBirthday()
        {
            people = people.OrderBy(p => p.Birthday).ToList();
        }
        public void sortByName() {
            people = people.OrderBy(p => p.Name).ToList();
        }
        public List<Person> search(string searchQuery)
        {
            // return people.FirstOrDefault(p => (p.Name + " " + p.Surname).Equals(searchQuery, StringComparison.OrdinalIgnoreCase)) ?? null;
            return people.Where(p => (p.Name + " " + p.Surname).Equals(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Person> searchByName(string searchQuery)
        {
            return people.Where(p => p.Name.Equals(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Person> searchBySurname(string searchQuery)
        {
            return people.Where(p => p.Surname.Equals(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public Person youngest()
        {
            return people.OrderByDescending(p => p.Birthday).First();
        }
        public Person oldest()
        {
            return people.OrderBy(p => p.Birthday).First();
        }
        public List<Person> upcomingBirthdays()
        {
            List<Person> upcomingBirthdays = people.Where(p => p.Birthday.Month == DateTime.Today.Month && p.Birthday.Day >= DateTime.Today.Day).ToList();
            upcomingBirthdays = upcomingBirthdays.OrderBy(p => p.Birthday.Day).ToList();
            return upcomingBirthdays;
        }
        public void addPerson(string name, string surname, int year, int month, int day)
        {
            DateTime birthday = new DateTime(year, month, day);
            Person p = new Person(name, surname, birthday);
            people.Add(p);
        }
        public void addPerson(Person p)
        {
            people.Add(p);
        }
        public static Person? stringToPerson(string input)
        {
            string[] parts = input.Split(';');
            if (parts.Length != 4)
            {
                return null;
            }
            Console.WriteLine(parts[0]);
            Console.WriteLine(parts[1]);
            Console.WriteLine(parts[2]);
            Console.WriteLine(parts[3]);
            string[] fullName = parts[0].Split(' ');
            // DateTime birthday = new DateTime(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
            int year, month, day;
            if (fullName.Length == 2 && !(string.IsNullOrWhiteSpace(fullName[0]) || string.IsNullOrWhiteSpace(fullName[1])))
            {
                if (int.TryParse(parts[1], out year) && int.TryParse(parts[2], out month) && int.TryParse(parts[3], out day))
                {
                    DateTime birthday = new DateTime(year, month, day);
                    Person p = new Person(fullName[0], fullName[1], birthday);
                    return p;
                }
            }
            return null;
        }
    }

}
