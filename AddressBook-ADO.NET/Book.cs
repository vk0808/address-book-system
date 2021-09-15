using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AddressBook_ADO.NET
{
    public class Book
    {
        // method to manage server connection
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(LocalDb)\localDb;Initial Catalog=address_book;Integrated Security=True");
        }

        SqlConnection BookConnection;

        // method to update db
        public string[] UpdatePersonCityState(PersonUpdateModel personUpdateModel)
        {
            BookConnection = ConnectionSetup();

            string[] cityState = new string[2];
            try
            {
                using (BookConnection)
                {
                    string id = "13";

                    string query = @"SELECT * FROM address WHERE BookID =" + Convert.ToInt32(id);
                    PersonModel displayModel = new PersonModel();

                    SqlCommand command = new SqlCommand("spUpdatePersonCityState", BookConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BookID", personUpdateModel.BookID);
                    command.Parameters.AddWithValue("@City", personUpdateModel.City);
                    command.Parameters.AddWithValue("@State", personUpdateModel.State);

                    BookConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.BookID = Convert.ToInt32(dr["BookID"]);
                            displayModel.City = dr["City"].ToString();
                            displayModel.State = dr["State"].ToString();
                            cityState[0] = dr["City"].ToString();
                            cityState[1] = dr["State"].ToString();

                            Console.WriteLine(displayModel.BookID + " " + displayModel.City + " " + displayModel.State + "\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                BookConnection.Close();
            }
            return cityState;
        }

        // method to retrieve person by specific date period
        public bool RetrievePerson_BetweenParticularDate()
        {
            BookConnection = ConnectionSetup();
            try
            {
                PersonModel displayModel = new PersonModel();

                using (BookConnection)
                {
                    SqlCommand command = new SqlCommand("SELECT FirstName, LastName FROM address WHERE AddedDate BETWEEN '2019-07-12' and GETDATE();", BookConnection);

                    BookConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.FirstName = dr.GetString(0);
                            displayModel.LastName = dr.GetString(1);
                            Console.WriteLine(displayModel.FirstName + " " + displayModel.LastName);
                        }
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                BookConnection.Close();
            }
            return false;
        }

        // method to find count of records fron db
        public bool FindCount()
        {
            BookConnection = ConnectionSetup();
            try
            {
                string cityState = "Bangalore";
                PersonModel displayModel = new PersonModel();

                using (BookConnection)
                {
                    SqlCommand command = new SqlCommand($"SELECT COUNT(FirstName) AS CityStateCount FROM address WHERE CITY = '{cityState}';", BookConnection);
                    int countPerson = 0;

                    BookConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            countPerson = dr.GetInt32(0);
                            Console.WriteLine(cityState + ": " + countPerson);

                        }
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                BookConnection.Close();
            }
            return false;
        }

        // method to add new record to table
        public bool AddNewRecord(PersonModel model)
        {
            BookConnection = ConnectionSetup();

            try
            {
                using (BookConnection)
                {
                    SqlCommand command = new SqlCommand("SpAddPersonDetails", BookConnection);
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

                    BookConnection.Open();
                    var result = command.ExecuteNonQuery();
                    BookConnection.Close();
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
                BookConnection.Close();
            }
            return false;
        }
    }
}
