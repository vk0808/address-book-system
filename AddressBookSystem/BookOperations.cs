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
        public void view(Action<Person> action)
        {
            People.ForEach(action);
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
                string msg = "\nFirst Name: {0}\nLast Name: {1}\nPhone Number: {2}\nEmail Id: {3}\nAddress: {4}\nCity: {5}\nState: {6}\nZIP Code: {7}\n";
                info.ForEach((item) => Console.WriteLine(msg, item.firstName, item.lastName, item.phoneNumber, item.email, item.address, item.city, item.state, item.zip));
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
                string msg = "\nFirst Name: {0}\nLast Name: {1}\nPhone Number: {2}\nEmail Id: {3}\nAddress: {4}\nCity: {5}\nState: {6}\nZIP Code: {7}\n";
                info.ForEach((item) => Console.WriteLine(msg, item.firstName, item.lastName, item.phoneNumber, item.email, item.address, item.city, item.state, item.zip));
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
                string msg = "\nFirst Name: {0}\nLast Name: {1}\nPhone Number: {2}\nEmail Id: {3}\nAddress: {4}\nCity: {5}\nState: {6}\nZIP Code: {7}\n";
                info.ForEach((item) => Console.WriteLine(msg, item.firstName, item.lastName, item.phoneNumber, item.email, item.address, item.city, item.state, item.zip));
            }
            else if (type.ToLower() == "state")
            {
                List<Person> info = People.FindAll(a => (a.state == name));
                Console.WriteLine($"\nCount: {info.Count}");
                string msg = "\nFirst Name: {0}\nLast Name: {1}\nPhone Number: {2}\nEmail Id: {3}\nAddress: {4}\nCity: {5}\nState: {6}\nZIP Code: {7}\n";
                info.ForEach((item) => Console.WriteLine(msg, item.firstName, item.lastName, item.phoneNumber, item.email, item.address, item.city, item.state, item.zip));
            }
            else
            {
                Console.WriteLine("\nPerson not found");
            }
        }

        // Method to sort list by person name
        public void SortList()
        {
            People = People.OrderBy(person => person.firstName).ToList();
            string msg = "First Name: {0}\nLast Name: {1}\nPhone Number: {2}\nEmail Id: {3}\nAddress: {4}\nCity: {5}\nState: {6}\nZIP Code: {7}\n";
            view((item) => Console.WriteLine(msg, item.firstName, item.lastName, item.phoneNumber, item.email, item.address, item.city, item.state, item.zip));
        }
    }
}
