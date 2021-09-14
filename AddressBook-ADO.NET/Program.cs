using System;

namespace AddressBook_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("Address Book ADO.NET\n");

            // Object instantiation
            PersonModel person = new PersonModel();
            AddressBookRepo repo = new AddressBookRepo();

            // Call method
            repo.GetAllPeople();
        }
    }
}
