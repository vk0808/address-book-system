﻿using System;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();

            Console.WriteLine(addressBook.welcome());
        }
    }
}
