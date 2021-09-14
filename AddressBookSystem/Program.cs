using System;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // object instantiation
            AddressBook addressBook = new AddressBook();

            // display welcome message
            Console.WriteLine(addressBook.welcome());

            // display menu and perform tasks based on choice
            addressBook.Selection();
        }
    }
}
