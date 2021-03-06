using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook_ADO.NET
{
    public class AddressBookRepo
    {
        // Variable to store Server connection
        public static string connectionString = @"Data Source=(LocalDb)\localDb;Initial Catalog=address_book;Integrated Security=True";

        SqlConnection connection;


        // Method to retrieve records from dbo.table
        public void GetAllPeople()
        {
            connection = new SqlConnection(connectionString);

            try
            {
                PersonModel personModel = new PersonModel();
                using (this.connection)
                {
                    string query = @"SELECT * FROM address_book.dbo.address;";

                    SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        Console.WriteLine($"{"BookID",5} {"FirstName",10} {"LastName",10} {"Address",25} {"City",10} {"State",10} {"Zip",10} {"PhoneNumber",15} {"Email",15}");
                        Console.Write($"{new string('-', 120)}\n");
                        while (dr.Read())
                        {
                            personModel.BookID = dr.GetInt32(0);
                            personModel.FirstName = dr.GetString(1);
                            personModel.LastName = dr.GetString(2);
                            personModel.Address = dr.GetString(3);
                            personModel.City = dr.GetString(4);
                            personModel.State = dr.GetString(5);
                            personModel.Zip = dr.GetString(6);
                            personModel.PhoneNumber = dr.GetString(7);
                            personModel.Email = dr.GetString(8);
                            Console.WriteLine($"{personModel.BookID,5} {personModel.FirstName,10} {personModel.LastName,10} {personModel.Address,25} {personModel.City,10} {personModel.State,10} {personModel.Zip,10} {personModel.PhoneNumber,15} {personModel.Email,15}");
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo data found");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Method to add records to table
        public bool AddPerson(PersonModel model)
        {
            connection = new SqlConnection(connectionString);

            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddPersonDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@BookName", model.BookName);
                    command.Parameters.AddWithValue("@BookType", model.BookType);

                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
    }
}
