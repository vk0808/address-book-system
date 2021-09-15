using AddressBook_ADO.NET;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressBook_ADO.NET_Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void CheckThreading_WhenAdding_PersonToBook()
        {
            BookThreadOperations addressBookOperations = new BookThreadOperations();
            DateTime startDateTime = DateTime.Now;
            addressBookOperations.AddPersonToBook_WithoutThread();
            DateTime stopDateTime = DateTime.Now;
            TimeSpan v1 = (stopDateTime - startDateTime);
            Console.WriteLine("Duration without thread: " + v1);

            DateTime startDateTimeThread = DateTime.Now;
            addressBookOperations.AddPersonToBook_WithThread();
            DateTime stopDateTimeThread = DateTime.Now;
            TimeSpan v2 = (stopDateTimeThread - startDateTimeThread);
            Console.WriteLine("Duration with thread: " + v2);

            Assert.AreNotEqual(v1, v2);
        }
    }
}
