﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBook
    {
        List<Person> People;

        // constructor
        public AddressBook()
        {
            People = new List<Person>();
        }

        // method to display message
        public string welcome()
        {
            return "Welcome to Address Book Program";
        }

        // method to get user's choice
        public void Selection()
        {
            string choice = "";
            displayMenu();
            while (!choice.ToUpper().Equals("Q"))
            {
                Console.WriteLine("\nSelection: ");
                choice = Console.ReadLine();
                performAction(choice);
            }
        }

        // method to display menu
        private void displayMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("------------------------------");
            Console.WriteLine("A - Add an Address");
            Console.WriteLine("L - List All Addresses");
            Console.WriteLine("Q - Quit");
        }

        // method to perform action based on choice
        public void performAction(string selection)
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            details.Add("First_Name", "");
            details.Add("Last_Name", "");
            details.Add("Phone_number", "");
            details.Add("Email_ID", "");
            details.Add("Address", "");
            details.Add("City", "");
            details.Add("State", "");
            details.Add("ZIP_Code", "");

            switch (selection.ToUpper())
            {
                // add an Address
                case "A":
                    List<string> keys = new List<string>(details.Keys);
                    foreach (string key in keys)
                    {
                        Console.WriteLine($"\nEnter {key}");
                        details[key] = Console.ReadLine();
                    }

                    if (add(details["First_Name"], details["Last_Name"], details["Phone_number"], details["Email_ID"], details["Address"], details["City"], details["State"], details["ZIP_Code"]))
                    {
                        Console.WriteLine("\nAddress successfully added!");
                    }
                    else
                    {
                        Console.WriteLine("\nAn address is already on file for {0}.", details["First_Name"]);
                    }
                    break;

                // list addresses
                case "L":
                    if (isEmpty())
                    {
                        Console.WriteLine("\nThere are no entries.");
                    }
                    else
                    {
                        Console.WriteLine("\nAddresses:");
                        string msg = "First Name: {0}\nLast Name: {1}\nPhone Number: {2}\nEmail Id: {3}\nAddress: {4}\nCity: {5}\nState: {6}\nZIP Code: {7}\n";
                        view((item) => Console.WriteLine(msg, item.firstName, item.lastName, item.phoneNumber, item.email, item.address, item.city, item.state, item.zip));
                    }
                    break;

                default:
                    break;
            }
        }

        // methpd to add an address to list
        public bool add(string firstName, string lastName, string phoneNumber, string email, string address, string city, string state, string zip)
        {
            Person person = new Person(firstName, lastName, phoneNumber, email, address, city, state, zip);
            Person result = find(firstName);

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
        public Person find(string name)
        {
            Person info = People.Find((a) => a.firstName == name);
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
    }
}
