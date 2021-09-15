﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook_ADO.NET
{
    public class PersonModel
    {
        // Instance variables
        public int BookID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BookName { get; set; }
        public string BookType { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
