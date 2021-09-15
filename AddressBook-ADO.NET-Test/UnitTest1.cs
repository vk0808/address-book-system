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
    }
}
