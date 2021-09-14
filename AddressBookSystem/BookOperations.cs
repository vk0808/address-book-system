using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class BookOperations
    {

        List<Person> People;

        // constructor
        public BookOperations()
        {
            People = new List<Person>();
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
    }
}
