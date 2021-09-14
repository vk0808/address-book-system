using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class DictionaryOperations
    {
        Dictionary<string, List<Person>> bookDictionary = new Dictionary<string, List<Person>>();

        public void AddAddressBook(string bookName)
        {
            List<Person> People = new List<Person>();
            if (bookDictionary.ContainsKey(bookName))
            {
                Console.WriteLine("\nThis AddressBook already exists");
            }
            else
            {
                bookDictionary.Add(bookName, People);
                Console.WriteLine("\nAddressBook Created.");
            }
        }
        public void GetAddressBook()
        {
            if (bookDictionary.Count > 0)
            {
                Console.WriteLine("\nAddress Book Names: ");
                foreach (KeyValuePair<string, List<Person>> book in bookDictionary)
                {
                    Console.WriteLine("{0}", book.Key);
                }
            }
            else
            {
                Console.WriteLine("\nNo AddressBook present");
            }
        }

        public void OpenAddressBook(string bookName)
        {
            if (bookDictionary.ContainsKey(bookName))
            {
                List<Person> contactList = bookDictionary[bookName];
                AddressBook book = new AddressBook(contactList);
                book.Selection();
            }
            else
            {
                Console.WriteLine("\nThis AddressBook already exists");
            }
        }
    }
}
