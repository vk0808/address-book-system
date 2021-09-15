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
        public void GivenAddressBook_OnGet_ReturnContactList()
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

        [TestMethod]
        public void GivenAddressBook_OnPost_ReturnAddedPerson()
        {
            RestRequest request = new RestRequest("/addressBook", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("firstName", "Rajiv");
            jObjectbody.Add("lastName", "Kumar");
            jObjectbody.Add("phoneNumber", "4356789211");
            jObjectbody.Add("email", "rajiv@gmail.com");
            jObjectbody.Add("address", "3rd Phase");
            jObjectbody.Add("city", "Bangalore");
            jObjectbody.Add("state", "Karnataka");
            jObjectbody.Add("zip", "560072");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //act
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
            AddressBook dataResponse = JsonConvert.DeserializeObject<AddressBook>(response.Content);
            Assert.AreEqual("Rajiv", dataResponse.FirstName);
            Assert.AreEqual("4356789211", dataResponse.PhoneNumber);
        }

        [TestMethod]
        public void GivenAddressBook_OnPut_ReturnUpdatedPerson()
        {
            RestRequest request = new RestRequest("/addressBook/update/4", Method.PUT);
            JObject jObjectbody = new JObject();

            jObjectbody.Add("firstName", "Rajiv");
            jObjectbody.Add("lastName", "Chandra");
            jObjectbody.Add("phoneNumber", "4356789211");
            jObjectbody.Add("email", "rajiv@gmail.com");
            jObjectbody.Add("address", "3rd Phase");
            jObjectbody.Add("city", "Bangalore");
            jObjectbody.Add("state", "Karnataka");
            jObjectbody.Add("zip", "560072");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //act
            var response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            AddressBook dataResponse = JsonConvert.DeserializeObject<AddressBook>(response.Content);
            Assert.AreEqual("Rajiv", dataResponse.FirstName);
            Assert.AreEqual("Chandra", dataResponse.LastName);

        }

        [TestMethod]
        public void GivenPersonID_OnDelete_SholudDeletePerson()
        {
            RestRequest requestDelete = new RestRequest("/addressBook/2", Method.DELETE);
            IRestResponse responseDelete = client.Execute(requestDelete);
            Assert.AreEqual(responseDelete.StatusCode, System.Net.HttpStatusCode.OK);

            RestRequest requestGet = new RestRequest("/addressBook/2", Method.GET);
            IRestResponse response = client.Execute(requestGet);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.NotFound);
        }
    }
}
