using System;

namespace AddressBookSystem
{
    class Program
    {
        public static DictionaryOperations dictionaryOP = new DictionaryOperations();

        // method to get user's choice
        public static void MainMenu()
        {
            string choice;
            while (true)
            {
                Console.WriteLine("\nWhat would you like to do: \n1. Add new AddressBook\n2. Open an AddressBook\n3. View AddressBooks\n4. Quit");
                choice = Console.ReadLine();
                string bookName;
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nEnter name of new Addressbook you want to create : ");
                        bookName = Console.ReadLine();
                        dictionaryOP.AddAddressBook(bookName);
                        break;

                    case "2":
                        Console.WriteLine("\nEnter name of Addressbook you want to open : ");
                        bookName = Console.ReadLine();
                        dictionaryOP.OpenAddressBook(bookName);
                        break;

                    case "3":
                        dictionaryOP.GetAddressBook();
                        break;

                    case "4":
                        Console.WriteLine("\nQuitting....");
                        dictionaryOP.WriteFile();
                        dictionaryOP.WriteCSV();
                        dictionaryOP.WriteJSON();

                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nYou have entered wrong index");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            // display message
            Console.WriteLine("Welcome to Address Book Program\n");

            dictionaryOP.ReadFromFile();
            dictionaryOP.ReadCSV();
            dictionaryOP.ReadJSON();

            MainMenu();
        }
    }
}
