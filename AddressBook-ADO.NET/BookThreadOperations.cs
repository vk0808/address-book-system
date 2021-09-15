using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook_ADO.NET
{
    public class BookThreadOperations
    {
        static PerformanceCounter myCounter;

        // Object instantiation
        AddressBookRepo repo = new AddressBookRepo();

        // Method to return Person data model
        public PersonModel PersonData()
        {
            PersonModel person = new PersonModel();
            //Add record
            person.FirstName = "Madan";
            person.LastName = "Kumar";
            person.Address = "13th cross";
            person.City = "Hyderabad";
            person.State = "Andhra Pradesh";
            person.Zip = "522403";
            person.PhoneNumber = "1234567890";
            person.Email = "kumar@gmail.com";
            person.BookName = "book3";
            person.BookType = "Profession";
            return person;
        }

        // Method to add person without threading
        public void AddPersonToBook_WithoutThread()
        {
            Console.WriteLine("Person is being added");
            PersonModel person = PersonData();
            person.FirstName = "Arun";
            if (repo.AddPerson(person))
            {
                Console.WriteLine("Person is added");
            }
            else
            {
                Console.WriteLine("Person is not added");
            }
        }

        // Method to add person with threading
        public void AddPersonToBook_WithThread()
        {

            if (!PerformanceCounterCategory.Exists("Processor"))
            {
                Console.WriteLine("Object Processor does not exist!");
                return;
            }
            if (!PerformanceCounterCategory.CounterExists(@"% Processor Time", "Thread"))
            {
                Console.WriteLine(@"Counter % Processor Time does not exist!");
                return;
            }

            myCounter = new PerformanceCounter("Processor", @"% Processor Time", @"_Total");
            Console.WriteLine(@"Before inserting, %Processor Time, _Total= " + myCounter.NextValue().ToString());
            Task thread = new Task(() =>
            {
                Console.WriteLine("Person is being added");
                PersonModel person = PersonData();
                person.FirstName = "Punith";
                if (repo.AddPerson(person))
                {
                    Console.WriteLine("Person is added");
                }
                else
                {
                    Console.WriteLine("Person is not added");
                }
            });
            thread.Start();
            Thread.Sleep(1000);
            Console.WriteLine(@"Current value of Processor, %Processor Time, _Total= " + myCounter.NextValue().ToString());
        }
    }
}
