using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AddressBookSystem
{
    class BookOperations
    {
        List<Person> People;

        // constructor
        public BookOperations(List<Person> contactList)
        {
            People = contactList;
        }

        // methpd to add an address to list
        public bool add(string firstName, string lastName, string phoneNumber, string email, string address, string city, string state, string zip)
        {
            Person person = new Person(firstName, lastName, phoneNumber, email, address, city, state, zip);
            Person result = find(firstName, lastName);

            if (result == null)
            {
                People.Add(person);
                return true;
            }
            else
            {
                return false;
            }
        }

        // method to find an address from list
        public Person find(string firstName, string lastName)
        {
            Person info = People.Find((a) => (a.firstName == firstName && a.lastName == lastName));
            return info;
        }

        // method to view addresses in list
        private void view(List<Person> records)
        {
            Console.Write($"\n{"firstname",10} |{"lastname",10} |{"phone",15} |{"email",25} |{"address",20} |{"city",15} |{"state",15} |{"zip-code",10} |\n");
            Console.Write($"{new string('-', 134)} |\n");

            foreach (Person addressData in records)
            {
                Console.Write($"{addressData.firstName,10} |");
                Console.Write($"{addressData.lastName,10} |");
                Console.Write($"{addressData.phoneNumber,15} |");
                Console.Write($"{addressData.email,25} |");
                Console.Write($"{addressData.address,20} |");
                Console.Write($"{addressData.city,15} |");
                Console.Write($"{addressData.state,15} |");
                Console.Write($"{addressData.zip,10} |\n");
            }
            Console.Write($"{new string('-', 134)} |\n\n");
        }

        public void viewAll()
        {
            view(People);
        }

        // method to check if list is empty
        public bool isEmpty()
        {
            return (People.Count == 0);
        }

        // method to delete an address
        public bool delete(string firstName, string lastName)
        {
            Person person = find(firstName, lastName);

            if (person != null)
            {
                People.Remove(person);
                return true;
            }
            else
            {
                return false;
            }
        }

        // method to view by City
        public void viewByCity(string personName, string name)
        {
            List<Person> info = People.FindAll(a => (a.firstName == personName && a.city == name));
            if (info.Count == 0)
            {
                Console.WriteLine("\nPerson not found");
            }
            else
            {
                view(info);
            }
        }

        // method to view by State
        public void viewByState(string personName, string name)
        {
            List<Person> info = People.FindAll(a => (a.firstName == personName && a.state == name));
            if (info.Count == 0)
            {
                Console.WriteLine("\nPerson not found");
            }
            else
            {
                view(info);
            }
        }

        // Method to search
        public void SearchByCityState(string type, string name, string personName)
        {
            if (isEmpty())
            {
                Console.WriteLine("\nAdress book is empty");
            }
            else
            {
                if (type.ToLower() == "city")
                {
                    viewByCity(personName, name);
                }
                else if (type.ToLower() == "state")
                {
                    viewByState(personName, name);
                }
            }
        }

        /// Method to view all addresses by city or state
        public void viewByCityState(string type, string name)
        {
            if (type.ToLower() == "city")
            {
                List<Person> info = People.FindAll(a => (a.city == name));
                Console.WriteLine($"\nCount: {info.Count}");
                view(info);
            }
            else if (type.ToLower() == "state")
            {
                List<Person> info = People.FindAll(a => (a.state == name));
                Console.WriteLine($"\nCount: {info.Count}");
                view(info);
            }
            else
            {
                Console.WriteLine("\nPerson not found");
            }
        }

        // Method to sort list by person name/city/state/zip
        public void SortList()
        {
            Console.WriteLine("\nSort by: \n1. Name\n2. City\n3. State\n4.ZIP Code");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    People = People.OrderBy(person => person.firstName).ToList();
                    break;

                case "2":
                    People = People.OrderBy(person => person.city).ToList();
                    break;

                case "3":
                    People = People.OrderBy(person => person.state).ToList();
                    break;

                case "4":
                    People = People.OrderBy(person => person.zip).ToList();
                    break;

                default:
                    Console.WriteLine("\nYou have entered wrong option");
                    break;
            }
            view(People);
        }
    }
}
