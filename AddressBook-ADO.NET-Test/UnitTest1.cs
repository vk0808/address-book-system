using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook_ADO.NET;

namespace AddressBook_ADO.NET_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenCityState_AbleToUpdatePersonDetails()
        {
            Book book = new Book();
            PersonUpdateModel updateModel = new PersonUpdateModel()
            {
                BookID = 13,
                City = "Vizag",
                State = "Andhra Pradesh"
            };

            string cityState = book.UpdatePersonCityState(updateModel)[0];
            Assert.AreEqual(updateModel.City, cityState);
        }

        [TestMethod]
        public void GivenDateRange_ShouldReturnPersonName()
        {
            Book book = new Book();
            var personName = book.RetrievePerson_BetweenParticularDate();
            Assert.IsTrue(personName);
        }

        [TestMethod]
        public void GivenNothing_ShouldReturnCount()
        {
            Book book = new Book();
            var countPerson = book.FindCount();
            Assert.IsTrue(countPerson);
        }

        [TestMethod]
        public void GivenPersonDetails_ShouldAddNewRecord()
        {
            Book book = new Book();
            PersonModel person = new PersonModel()
            {
                FirstName = "Madana",
                LastName = "Mohana",
                Address = "13th cross",
                City = "Hyderabad",
                State = "Andhra Pradesh",
                Zip = "522403",
                PhoneNumber = "1234567890",
                Email = "mohan@gmail.com",
                BookName = "book3",
                BookType = "Profession",
            };

            var personName = book.AddNewRecord(person);
            Assert.IsTrue(personName);
        }
    }
}
