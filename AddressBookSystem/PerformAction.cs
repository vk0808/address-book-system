using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class PerformAction
    {
        // object instantiation
        BookOperations operations;

        public PerformAction(List<Person> contactList)
        {
            operations = new BookOperations(contactList);
        }

        // method to perform action based on choice
        public void actions(string selection)
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

                    if (operations.add(details["First_Name"], details["Last_Name"], details["Phone_number"], details["Email_ID"], details["Address"], details["City"], details["State"], details["ZIP_Code"]))
                    {
                        Console.WriteLine("\nAddress successfully added!");
                    }
                    else
                    {
                        Console.WriteLine($"\nAn address is already on file for {details["First_Name"]} {details["Last_Name"]}.");
                    }
                    break;

                // list addresses
                case "V":
                    if (operations.isEmpty())
                    {
                        Console.WriteLine("\nThere are no entries.");
                    }
                    else
                    {
                        Console.Write("\nView by\n1. City\n2. State\n3. All\nEnter your option: ");
                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                Console.Write("\nEnter the name of city: ");
                                string cityName = Console.ReadLine();
                                Console.WriteLine("\nAddresses:");

                                operations.viewByCityState("city", cityName);
                                break;

                            case 2:
                                Console.Write("\nEnter the name of state: ");
                                string stateName = Console.ReadLine();
                                Console.WriteLine("\nAddresses:");

                                operations.viewByCityState("state", stateName);
                                break;

                            case 3:
                                Console.WriteLine("\nAddresses:");
                                operations.viewAll();
                                break;

                            default:
                                Console.WriteLine("\nInvalid option");
                                return;
                        }
                    }
                    break;

                // edit an address
                case "E":
                    Console.WriteLine("\nEnter the first name: ");
                    string editPersonFirst = Console.ReadLine();
                    Console.WriteLine("\nEnter the last name: ");
                    string editPersonLast = Console.ReadLine();

                    Person person = operations.find(editPersonFirst, editPersonLast);
                    if (person == null)
                    {
                        Console.WriteLine($"\nAddress for {editPersonFirst} {editPersonLast} count not be found.");
                    }
                    else
                    {
                        Console.WriteLine("\nEnter index: \n0: First Name\n1: Last Name\n2: Phone number\n3: Email ID\n4: Address\n5: City\n6: State\n7: ZIP Code");
                        int editKey = int.Parse(Console.ReadLine());
                        switch (editKey)
                        {
                            case 0:
                                Console.WriteLine("\nEnter new First Name: ");
                                person.firstName = Console.ReadLine();
                                Console.WriteLine($"\nFirst Name updated for {editPersonFirst} {editPersonLast}");
                                break;
                            case 1:
                                Console.WriteLine("\nEnter new Last Name: ");
                                person.lastName = Console.ReadLine();
                                Console.WriteLine($"\nLast Name updated for {editPersonFirst} {editPersonLast}");
                                break;
                            case 2:
                                Console.WriteLine("\nEnter new Phone number: ");
                                person.phoneNumber = Console.ReadLine();
                                Console.WriteLine($"\nPhone Number updated for {editPersonFirst} {editPersonLast}");
                                break;
                            case 3:
                                Console.WriteLine("\nEnter new Email ID: ");
                                person.email = Console.ReadLine();
                                Console.WriteLine($"\nEmail Id updated for {editPersonFirst} {editPersonLast}");
                                break;
                            case 4:
                                Console.WriteLine("\nEnter new Address: ");
                                person.address = Console.ReadLine();
                                Console.WriteLine($"\nAddress updated for {editPersonFirst} {editPersonLast}");
                                break;
                            case 5:
                                Console.WriteLine("\nEnter new City: ");
                                person.city = Console.ReadLine();
                                Console.WriteLine($"\nCity updated for {editPersonFirst} {editPersonLast}");
                                break;
                            case 6:
                                Console.WriteLine("\nEnter new State: ");
                                person.state = Console.ReadLine();
                                Console.WriteLine($"\nState updated for {editPersonFirst} {editPersonLast}");
                                break;
                            case 7:
                                Console.WriteLine("\nEnter new ZIP Code: ");
                                person.zip = Console.ReadLine();
                                Console.WriteLine($"\nZIP Code updated for {editPersonFirst} {editPersonLast}");
                                break;
                            default:
                                Console.WriteLine("\nYou have entered wrong index");
                                break;
                        }
                    }
                    break;

                // Search by city or state
                case "S":
                    string personName;
                    Console.Write("\nSearch by\n1. City\n2. State\nEnter your option: ");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.Write("\nEnter the name of city: ");
                            string cityName = Console.ReadLine();
                            Console.Write("\nEnter the name of person: ");
                            personName = Console.ReadLine();
                            operations.SearchByCityState("city", cityName, personName);
                            break;
                        case 2:
                            Console.Write("\nEnter the name of state: ");
                            string stateName = Console.ReadLine();
                            Console.Write("\nEnter the name of person: ");
                            personName = Console.ReadLine();
                            operations.SearchByCityState("state", stateName, personName);
                            break;
                        default:
                            Console.WriteLine("\nInvalid option");
                            return;
                    }
                    break;

                // delete an address
                case "D":
                    Console.WriteLine("\nEnter First Name to Delete: ");
                    string delPersonFirst = Console.ReadLine();
                    Console.WriteLine("\nEnter Last Name to Delete: ");
                    string delPersonLast = Console.ReadLine();

                    if (operations.delete(delPersonFirst, delPersonLast))
                    {
                        Console.WriteLine("\nAddress successfully deleted");
                    }
                    else
                    {
                        Console.WriteLine($"\nAddress for {delPersonFirst} {delPersonLast} could not be found.");
                    }
                    break;

                // Sort the list by city
                case "O":
                    operations.SortList();
                    break;

                // quit
                case "Q":
                    Console.WriteLine("\nQuitting....");
                    break;

                default:
                    Console.WriteLine("\nYou have entered wrong option");
                    break;
            }
        }
    }
}
