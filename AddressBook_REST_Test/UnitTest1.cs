using AddressBook_REST;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp;
using System;
using System.Collections.Generic;

namespace AddressBook_REST_Test
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        private IRestResponse getAddressBookList()
        {
            RestRequest request = new RestRequest("/addressBook/list", Method.GET);

            //act

            IRestResponse response = client.Execute(request);
            return response;
        }

        [TestMethod]
        public void onCallingGETApi_ReturnContactList()
        {
            IRestResponse response = getAddressBookList();

            //assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            List<AddressBook> dataResponse = JsonConvert.DeserializeObject<List<AddressBook>>(response.Content);
            Assert.AreEqual(3, dataResponse.Count);
            foreach (AddressBook addressData in dataResponse)
            {
                System.Console.WriteLine("Id: " + addressData.BookID + "First Name: " + addressData.FirstName + "Last Name: " + addressData.LastName);
            }
        }
    }
}
