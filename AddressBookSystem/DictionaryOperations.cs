using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace AddressBookSystem
{
    class DictionaryOperations
    {
        List<Person> contacts;
        Dictionary<string, List<Person>> bookDictionary = new Dictionary<string, List<Person>>();

        public DictionaryOperations()
        {
            ReadFromFile();
        }

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

        // Method to read from file
        private void ReadFromFile()
        {
            string filePath = @"../../../Utility/AddressBook.txt";
            try
            {
                string[] fileContents = File.ReadAllLines(filePath);
                contacts = new List<Person>();

                BookOperations book = new BookOperations(contacts);
                foreach (string line in fileContents)
                {
                    if (line.Contains(","))
                    {
                        string[] address = line.Split(",");
                        if (!book.add(address[0], address[1], address[2], address[3], address[4], address[5], address[6], address[7]))
                        {
                            Console.WriteLine($"An address is already on file for {address[0]} {address[1]}\n");
                        }
                    }
                }
                string bookName = "default";
                if (bookDictionary.ContainsKey(bookName))
                {
                    Console.WriteLine("\nThis AddressBook already exists");
                }
                else
                {
                    bookDictionary.Add(bookName, contacts);
                    Console.WriteLine("\nAddressBook Created.");
                }
                Console.WriteLine("\nSuccessfully read from 'AddressBook.txt'!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // method to write to txt file
        public void WriteFile()
        {
            string file = @"../../../Utility/Address.txt";

            StreamWriter writer = new StreamWriter(file, true);
            foreach (List<Person> addresses in bookDictionary.Values)
            {
                foreach (Person person in addresses)
                {
                    writer.Write(person.firstName + ",");
                    writer.Write(person.lastName + ",");
                    writer.Write(person.phoneNumber + ",");
                    writer.Write(person.email + ",");
                    writer.Write(person.address + ",");
                    writer.Write(person.city + ",");
                    writer.Write(person.state + ",");
                    writer.Write(person.zip + Environment.NewLine);
                }
            }
            Console.WriteLine("\nSuccessfully wrote to 'Address.txt'");
            writer.Close();
        }
    }
}
