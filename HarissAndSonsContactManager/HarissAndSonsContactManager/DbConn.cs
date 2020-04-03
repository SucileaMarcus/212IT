using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarissAndSonsContactManager
{
    public class DbConn
    {
        private string connString = "Server=it212db.c4zu499kghzi.us-east-1.rds.amazonaws.com;User ID=admin;Password=Heemiola123!;Database=HarrisandSonsContactsDb;";

        public DataTable GetAllPersonal()
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                DataTable personalContactDt = new DataTable();
                List<PersonalContact> personalContacts = new List<PersonalContact>();
                using (var cmd = new MySqlCommand("CALL selectAllPersonal();", conn))

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        personalContacts.Add(new PersonalContact
                        {
                            ContactID = reader.GetInt32(0),
                            ContactFname = reader.GetString(1),
                            ContactLname = reader.GetString(2),
                            ContactEmail = reader.GetString(3),
                            ContactAddr1 = reader.GetString(4),
                            ContactAddr2 = reader.GetString(5),
                            ContactCity = reader.GetString(6),
                            ContactPostCode = reader.GetString(7),
                            PersonalTel = reader.GetString(8)
                        });

                    }

                personalContactDt.Columns.Add("ContactID");
                personalContactDt.Columns.Add("ContactFname");
                personalContactDt.Columns.Add("ContactLname");
                personalContactDt.Columns.Add("ContactEmail");
                personalContactDt.Columns.Add("ContactAddr1");
                personalContactDt.Columns.Add("ContactAddr2");
                personalContactDt.Columns.Add("ContactCity");
                personalContactDt.Columns.Add("ContactPostCode");
                personalContactDt.Columns.Add("PersonalTel");

                foreach (var item in personalContacts)
                {
                    var row = personalContactDt.NewRow();
                    row["ContactID"] = item.ContactID;
                    row["ContactFname"] = item.ContactFname;
                    row["ContactLname"] = item.ContactLname;
                    row["ContactEmail"] = item.ContactEmail;
                    row["ContactAddr1"] = item.ContactAddr1;
                    row["ContactAddr2"] = item.ContactAddr2;
                    row["ContactCity"] = item.ContactCity;
                    row["ContactPostCode"] = item.ContactPostCode;
                    row["PersonalTel"] = item.PersonalTel;

                    personalContactDt.Rows.Add(row);

                }
                return personalContactDt;
            }

        }

        public void InsertPersonal(PersonalContact personalContact)
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL insertPersonal(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8);";
                    cmd.Parameters.AddWithValue("p1", personalContact.ContactFname);
                    cmd.Parameters.AddWithValue("p2", personalContact.ContactLname);
                    cmd.Parameters.AddWithValue("p3", personalContact.ContactEmail);
                    cmd.Parameters.AddWithValue("p4", personalContact.ContactAddr1);
                    cmd.Parameters.AddWithValue("p5", personalContact.ContactAddr2);
                    cmd.Parameters.AddWithValue("p6", personalContact.ContactCity);
                    cmd.Parameters.AddWithValue("p7", personalContact.ContactPostCode);
                    cmd.Parameters.AddWithValue("p8", personalContact.PersonalTel);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void UpdatePersonal(PersonalContact personalContact)
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL updatePersonal(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9);";
                    cmd.Parameters.AddWithValue("p1", personalContact.ContactID);
                    cmd.Parameters.AddWithValue("p2", personalContact.ContactFname);
                    cmd.Parameters.AddWithValue("p3", personalContact.ContactLname);
                    cmd.Parameters.AddWithValue("p4", personalContact.ContactEmail);
                    cmd.Parameters.AddWithValue("p5", personalContact.ContactAddr1);
                    cmd.Parameters.AddWithValue("p6", personalContact.ContactAddr2);
                    cmd.Parameters.AddWithValue("p7", personalContact.ContactCity);
                    cmd.Parameters.AddWithValue("p8", personalContact.ContactPostCode);
                    cmd.Parameters.AddWithValue("p9", personalContact.PersonalTel);
                    cmd.ExecuteNonQuery();

                }
            }
        }
        public void DeletePersonal(int id)
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL deletePersonal(@p1);";
                    cmd.Parameters.AddWithValue("p1", id);
                    cmd.ExecuteNonQuery();

                }
            }

        }

        public DataTable GetAllBusiness()
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                DataTable businessContactDt = new DataTable();
                List<BusinessContact> businessContacts = new List<BusinessContact>();
                using (var cmd = new MySqlCommand("CALL selectAllBusiness();", conn))

                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        businessContacts.Add(new BusinessContact
                        {
                            ContactID = reader.GetInt32(0),
                            ContactFname = reader.GetString(1),
                            ContactLname = reader.GetString(2),
                            ContactEmail = reader.GetString(3),
                            ContactAddr1 = reader.GetString(4),
                            ContactAddr2 = reader.GetString(5),
                            ContactCity = reader.GetString(6),
                            ContactPostCode = reader.GetString(7),
                            BusinessTel = reader.GetString(8)
                        });

                    }

                businessContactDt.Columns.Add("ContactID");
                businessContactDt.Columns.Add("ContactFname");
                businessContactDt.Columns.Add("ContactLname");
                businessContactDt.Columns.Add("ContactEmail");
                businessContactDt.Columns.Add("ContactAddr1");
                businessContactDt.Columns.Add("ContactAddr2");
                businessContactDt.Columns.Add("ContactCity");
                businessContactDt.Columns.Add("ContactPostCode");
                businessContactDt.Columns.Add("BusinessTel");

                foreach (var item in businessContacts)
                {
                    var row = businessContactDt.NewRow();
                    row["ContactID"] = item.ContactID;
                    row["ContactFname"] = item.ContactFname;
                    row["ContactLname"] = item.ContactLname;
                    row["ContactEmail"] = item.ContactEmail;
                    row["ContactAddr1"] = item.ContactAddr1;
                    row["ContactAddr2"] = item.ContactAddr2;
                    row["ContactCity"] = item.ContactCity;
                    row["ContactPostCode"] = item.ContactPostCode;
                    row["BusinessTel"] = item.BusinessTel;

                    businessContactDt.Rows.Add(row);

                }
                return businessContactDt;
            }

        }
    
        public void InsertBusiness(BusinessContact businessContact)
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL insertBusiness(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8);";
                    cmd.Parameters.AddWithValue("p1", businessContact.ContactFname);
                    cmd.Parameters.AddWithValue("p2", businessContact.ContactLname);
                    cmd.Parameters.AddWithValue("p3", businessContact.ContactEmail);
                    cmd.Parameters.AddWithValue("p4", businessContact.ContactAddr1);
                    cmd.Parameters.AddWithValue("p5", businessContact.ContactAddr2);
                    cmd.Parameters.AddWithValue("p6", businessContact.ContactCity);
                    cmd.Parameters.AddWithValue("p7", businessContact.ContactPostCode);
                    cmd.Parameters.AddWithValue("p8", businessContact.BusinessTel);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void UpdateBusiness(BusinessContact businessContact)
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL udatePersonal(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9);";
                    cmd.Parameters.AddWithValue("p1", businessContact.ContactID);
                    cmd.Parameters.AddWithValue("p2", businessContact.ContactFname);
                    cmd.Parameters.AddWithValue("p3", businessContact.ContactLname);
                    cmd.Parameters.AddWithValue("p4", businessContact.ContactEmail);
                    cmd.Parameters.AddWithValue("p5", businessContact.ContactAddr1);
                    cmd.Parameters.AddWithValue("p6", businessContact.ContactAddr2);
                    cmd.Parameters.AddWithValue("p7", businessContact.ContactCity);
                    cmd.Parameters.AddWithValue("p8", businessContact.ContactPostCode);
                    cmd.Parameters.AddWithValue("p9", businessContact.BusinessTel);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void DeleteBusiness(int id)
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "CALL deleteBusiness(@p1);";
                    cmd.Parameters.AddWithValue("p1", id);
                    cmd.ExecuteNonQuery();

                }
            }

        }
    }
}
