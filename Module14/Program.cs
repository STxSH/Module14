using System.Runtime.InteropServices;

namespace Module14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            //сортировка по имени, затем по фамилии
            phoneBook = phoneBook.OrderBy(c => c.Name).ThenBy(c => c.LastName).ToList();

            bool appIsRun = true;
            while (appIsRun)
            {
                var key = Console.ReadKey().Key;
                Console.Clear();
                var keyChar = Convert.ToChar(key);

                if (key == ConsoleKey.Escape) 
                {
                    appIsRun = false;
                }
                else
                {                    
                    if (char.IsDigit(keyChar))
                    {
                        int pageNumber = int.Parse(keyChar.ToString());
                        DisplayContacts(phoneBook, pageNumber);
                    }
                    else
                    {
                        Console.WriteLine("wrong input");
                        continue;
                    }
                }                
            }
        }

        public static void DisplayContacts(List<Contact> contacts, int pageNumber)
        {
            int pageSize = 2;
            var page = contacts.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (page.Any())
            {
                foreach (var contact in page)
                {
                    Console.WriteLine($"{contact.Name} {contact.LastName}: {contact.PhoneNumber}, {contact.Email}");
                }
            }
            else
            {
                Console.WriteLine("page not found");
            }
        }
    }
}