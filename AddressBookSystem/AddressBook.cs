using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBook
    {
        List<Person> People;

        public AddressBook()
        {
            People = new List<Person>();
        }

        public string welcome()
        {
            return "Welcome to Address Book Program";
        }
    }
}
