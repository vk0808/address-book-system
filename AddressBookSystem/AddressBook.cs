﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBook
    {
        // object instantiation
        PerformAction perform = new PerformAction();

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
                displayMenu();
                Console.WriteLine("\nSelect an option: ");
                choice = Console.ReadLine();
                perform.actions(choice);
            }
        }

        // method to display menu
        private void displayMenu()
        {
            Console.WriteLine("\nMain Menu");
            Console.WriteLine("------------------------------");
            Console.WriteLine("V - View All Addresses");
            Console.WriteLine("A - Add an Address");
            Console.WriteLine("E - Edit an Address");
            Console.WriteLine("L - List All Addresses");
            Console.WriteLine("D - Delete an Address");
            Console.WriteLine("Q - Quit");
        }
    }
}
