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
    }
}
