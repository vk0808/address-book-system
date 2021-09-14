using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class PerformAction
    {
        // object instantiation
        BookOperations operations = new BookOperations();

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
                        Console.WriteLine("\nAn address is already on file for {0}.", details["First_Name"]);
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
                        Console.WriteLine("\nAddresses:");
                        string msg = "First Name: {0}\nLast Name: {1}\nPhone Number: {2}\nEmail Id: {3}\nAddress: {4}\nCity: {5}\nState: {6}\nZIP Code: {7}\n";
                        operations.view((item) => Console.WriteLine(msg, item.firstName, item.lastName, item.phoneNumber, item.email, item.address, item.city, item.state, item.zip));
                    }
                    break;

                // edit an address
                case "E":
                    Console.WriteLine("\nEnter the first name: ");
                    string editPerson = Console.ReadLine();
                    Person person = operations.find(editPerson);
                    if (person == null)
                    {
                        Console.WriteLine("\nAddress for {0} count not be found.", editPerson);
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
                                Console.WriteLine("\nFirst Name updated for {0}", editPerson);
                                break;
                            case 1:
                                Console.WriteLine("\nEnter new Last Name: ");
                                person.lastName = Console.ReadLine();
                                Console.WriteLine("\nLast Name updated for {0}", editPerson);
                                break;
                            case 2:
                                Console.WriteLine("\nEnter new Phone number: ");
                                person.phoneNumber = Console.ReadLine();
                                Console.WriteLine("\nPhone Number updated for {0}", editPerson);
                                break;
                            case 3:
                                Console.WriteLine("\nEnter new Email ID: ");
                                person.email = Console.ReadLine();
                                Console.WriteLine("\nEmail Id updated for {0}", editPerson);
                                break;
                            case 4:
                                Console.WriteLine("\nEnter new Address: ");
                                person.address = Console.ReadLine();
                                Console.WriteLine("\nAddress updated for {0}", editPerson);
                                break;
                            case 5:
                                Console.WriteLine("\nEnter new City: ");
                                person.city = Console.ReadLine();
                                Console.WriteLine("\nCity updated for {0}", editPerson);
                                break;
                            case 6:
                                Console.WriteLine("\nEnter new State: ");
                                person.state = Console.ReadLine();
                                Console.WriteLine("\nState updated for {0}", editPerson);
                                break;
                            case 7:
                                Console.WriteLine("\nEnter new ZIP Code: ");
                                person.zip = Console.ReadLine();
                                Console.WriteLine("\nZIP Code updated for {0}", editPerson);
                                break;
                            default:
                                Console.WriteLine("\nYou have entered wrong index");
                                break;
                        }
                    }
                    break;

                // delete an address
                case "D":
                    Console.WriteLine("\nEnter First Name to Delete: ");
                    string delPerson = Console.ReadLine();
                    if (operations.delete(delPerson))
                    {
                        Console.WriteLine("\nAddress successfully deleted");
                    }
                    else
                    {
                        Console.WriteLine("\nAddress for {0} could not be found.", delPerson);
                    }
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
