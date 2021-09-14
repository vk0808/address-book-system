using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Globalization;
using CsvHelper;
using Newtonsoft.Json;

namespace AddressBookSystem
{
    class DictionaryOperations
    {
        List<Person> contacts;
        Dictionary<string, List<Person>> bookDictionary = new Dictionary<string, List<Person>>();

        public void AddAddressBook(string bookName)
        {
            List<Person> People = new List<Person>();
            if (bookDictionary.ContainsKey(bookName))
            {
                Console.WriteLine("\nThis AddressBook already exists");
            }
            else
            {
                bookDictionary.Add(bookName, People);
                Console.WriteLine("\nAddressBook Created.");
            }
        }
        public void GetAddressBook()
        {
            if (bookDictionary.Count > 0)
            {
                Console.WriteLine("\nAddress Book Names: ");
                foreach (KeyValuePair<string, List<Person>> book in bookDictionary)
                {
                    Console.WriteLine("{0}", book.Key);
                }
            }
            else
            {
                Console.WriteLine("\nNo AddressBook present");
            }
        }

        public void OpenAddressBook(string bookName)
        {
            if (bookDictionary.ContainsKey(bookName))
            {
                List<Person> contactList = bookDictionary[bookName];
                AddressBook book = new AddressBook(contactList);
                book.Selection();
            }
            else
            {
                Console.WriteLine("\nNo AddressBook present");
            }
        }

        // Method to read from file
        public void ReadFromFile()
        {
            string filePath = @"../../../Utility/AddressBook.txt";
            try
            {
                string[] fileContents = File.ReadAllLines(filePath);
                contacts = new List<Person>();

                BookOperations book = new BookOperations(contacts);
                foreach (string line in fileContents)
                {
                    if (line.Contains(","))
                    {
                        string[] address = line.Split(",");
                        if (!book.add(address[0], address[1], address[2], address[3], address[4], address[5], address[6], address[7]))
                        {
                            Console.WriteLine($"An address is already on file for {address[0]} {address[1]}\n");
                        }
                    }
                }
                string bookName = "default";
                if (bookDictionary.ContainsKey(bookName))
                {
                    Console.WriteLine("\nThis AddressBook already exists");
                }
                else
                {
                    bookDictionary.Add(bookName, contacts);
                    Console.WriteLine("\nAddressBook Created.");
                }
                Console.WriteLine("\nSuccessfully read from 'AddressBook.txt'!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // method to write to txt file
        public void WriteFile()
        {
            string file = @"../../../Utility/Address.txt";

            StreamWriter writer = new StreamWriter(file, true);
            foreach (List<Person> addresses in bookDictionary.Values)
            {
                foreach (Person person in addresses)
                {
                    writer.Write(person.firstName + ",");
                    writer.Write(person.lastName + ",");
                    writer.Write(person.phoneNumber + ",");
                    writer.Write(person.email + ",");
                    writer.Write(person.address + ",");
                    writer.Write(person.city + ",");
                    writer.Write(person.state + ",");
                    writer.Write(person.zip + Environment.NewLine);
                }
            }
            Console.WriteLine("\nSuccessfully wrote to 'Address.txt'");
            writer.Close();
        }

        /// Method to write to csv file
        public void WriteCSV()
        {
            string exportFilePath = @"../../../Utility/Export.csv";


            using (var writer = new StreamWriter(exportFilePath))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach (List<Person> addresses in bookDictionary.Values)
                {
                    foreach (Person person in addresses)
                    {
                        csvWriter.WriteField(person.firstName);
                        csvWriter.WriteField(person.lastName);
                        csvWriter.WriteField(person.phoneNumber);
                        csvWriter.WriteField(person.email);
                        csvWriter.WriteField(person.address);
                        csvWriter.WriteField(person.city);
                        csvWriter.WriteField(person.state);
                        csvWriter.WriteField(person.zip);
                        csvWriter.NextRecord();
                    }
                }
            }
            Console.WriteLine("\nSuccessfully wrote to Export.csv\n");
        }

        /// Method to read from csv file
        public void ReadCSV()
        {
            string importFilePath = @"../../../Utility/Address.csv";

            // config for no header
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                IEnumerable<Person> records = csv.GetRecords<Person>();
                Console.WriteLine("\nRead data successfully from Address.csv\n");
                Console.Write($"\n{"firstname",10} |{"lastname",10} |{"phone",15} |{"email",25} |{"address",20} |{"city",15} |{"state",15} |{"zip-code",10} |\n");
                Console.Write($"{new string('-', 134)} |\n");

                foreach (Person addressData in records)
                {
                    Console.Write($"{addressData.firstName,10} |");
                    Console.Write($"{addressData.lastName,10} |");
                    Console.Write($"{addressData.phoneNumber,15} |");
                    Console.Write($"{addressData.email,25} |");
                    Console.Write($"{addressData.address,20} |");
                    Console.Write($"{addressData.city,15} |");
                    Console.Write($"{addressData.state,15} |");
                    Console.Write($"{addressData.zip,10} |\n");
                }
                Console.Write($"{new string('-', 134)} |\n\n");
            }
        }

        /// Method to write to json file
        public void WriteJSON()
        {
            string exportFilePath = @"../../../Utility/Address.json";
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            using (StreamWriter sw = new StreamWriter(exportFilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, bookDictionary);
            }
            Console.WriteLine("\nSuccessfully wrote to Export.json");
        }


        /// Method to read from json file
        public void ReadJSON()
        {
            string importFilePath = @"../../../Utility/Address.json";

            Console.WriteLine("\nSuccessfully read from Address.json");

            Dictionary<string, List<Person>> records = JsonConvert.DeserializeObject<Dictionary<string, List<Person>>>(File.ReadAllText(importFilePath));
            Console.WriteLine("\nRead data successfully from Address.json");
            Console.Write($"\n{"firstname",10} |{"lastname",10} |{"phone",15} |{"email",25} |{"address",20} |{"city",15} |{"state",15} |{"zip-code",10} |\n");
            Console.Write($"{new string('-', 134)} |\n");

            foreach (List<Person> addresses in records.Values)
            {
                foreach (Person addressData in addresses)
                {
                    Console.Write($"{addressData.firstName,10} |");
                    Console.Write($"{addressData.lastName,10} |");
                    Console.Write($"{addressData.phoneNumber,15} |");
                    Console.Write($"{addressData.email,25} |");
                    Console.Write($"{addressData.address,20} |");
                    Console.Write($"{addressData.city,15} |");
                    Console.Write($"{addressData.state,15} |");
                    Console.Write($"{addressData.zip,10} |\n");
                }
                Console.Write($"{new string('-', 134)} |\n\n");
            }
        }
    }
}
