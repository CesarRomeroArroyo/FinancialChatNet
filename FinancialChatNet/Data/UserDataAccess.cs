using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Transversal.Models;
using Data.Interfaces;

namespace Data
{
    public class UserDataAccess : IUserDataAccess
    {
        public string dataBase = "financialChatNet";


        public UserModel login(string user, string password)
        {
            UserModel userReturn = new UserModel();
            var dbCon = DataAcces.Instance();
            dbCon.DatabaseName = dataBase;
            if (dbCon.IsConnect())
            {
                var comm = dbCon.Connection.CreateCommand();
                comm.CommandText = "SELECT * FROM `users` WHERE email =@email AND password =@password ";
                comm.Parameters.AddWithValue("?email", user);
                comm.Parameters.AddWithValue("?password", password);
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        userReturn.id = Convert.ToInt32(reader.GetString(0));
                        userReturn.email = reader.GetString(1);
                        userReturn.password = reader.GetString(2);
                    }
                }
            }
            return userReturn;
        }

        public List<UserModel> getListUser(string userId) {
            List<UserModel> listUserReturn = new List<UserModel>();
            var dbCon = DataAcces.Instance();
            dbCon.DatabaseName = dataBase;
            if (dbCon.IsConnect())
            {
                var comm = dbCon.Connection.CreateCommand();
                comm.CommandText = "SELECT * FROM `users` WHERE id !=@id";
                comm.Parameters.AddWithValue("?id", userId);
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserModel userReturn = new UserModel();
                        userReturn.id = Convert.ToInt32(reader.GetString(0));
                        userReturn.email = reader.GetString(1);
                        userReturn.password = reader.GetString(2);
                        listUserReturn.Add(userReturn);
                    }
                }
            }
            return listUserReturn;

        }

        public bool createUser(string email, string password)
        {
            if (!verifyUserExists(email))
            {
                var dbCon = DataAcces.Instance();
                dbCon.DatabaseName = dataBase;
                if (dbCon.IsConnect())
                {
                    var comm = dbCon.Connection.CreateCommand();
                    comm.CommandText = "INSERT INTO users(email,password) VALUES(@email, @password)";
                    comm.Parameters.AddWithValue("?email", email);
                    comm.Parameters.AddWithValue("?password", password);
                    comm.ExecuteNonQuery();
                    return true;
                }
            }
            return false;
        }

        public bool verifyUserExists(string email)
        {
            List<UserModel> listUserReturn = new List<UserModel>();
            var dbCon = DataAcces.Instance();
            dbCon.DatabaseName = dataBase;
            if (dbCon.IsConnect())
            {
                var comm = dbCon.Connection.CreateCommand();
                comm.CommandText = "SELECT * FROM `users` WHERE email =@email";
                comm.Parameters.AddWithValue("?email", email);
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserModel userReturn = new UserModel();
                        userReturn.id = Convert.ToInt32(reader.GetString(0));
                        userReturn.email = reader.GetString(1);
                        userReturn.password = reader.GetString(2);
                        listUserReturn.Add(userReturn);
                    }
                }
            }

            if (listUserReturn.Count > 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}
