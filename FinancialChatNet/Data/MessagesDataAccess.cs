using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Transversal.Models;
using Data.Interfaces;

namespace Data
{
    public class MessagesDataAccess : IMessagesDataAccess
    {
        public string dataBase = "financialChatNet";

        public List<MessageModel> getMessageByProducer(string producer)
        {
            List<MessageModel> listMessagereturn = new List<MessageModel>();
            var dbCon = DataAcces.Instance();
            dbCon.DatabaseName = dataBase;
            if (dbCon.IsConnect())
            {
                var comm = dbCon.Connection.CreateCommand();
                comm.CommandText = "SELECT * FROM `messages` WHERE producer =@producer ORDER BY date DESC LIMIT 0,50";
                comm.Parameters.AddWithValue("?producer", producer);
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MessageModel messageReturn = new MessageModel();
                        messageReturn.id = reader.GetInt32(0);
                        messageReturn.producer = reader.GetString(1);
                        messageReturn.consumer = reader.GetString(2);
                        messageReturn.message = reader.GetString(3);
                        messageReturn.date = reader.GetString(4);
                        listMessagereturn.Add(messageReturn);
                    }
                }
            }
            return listMessagereturn;
        }

        public bool addMessage(MessageModel message)
        {
            var dbCon = DataAcces.Instance();
            dbCon.DatabaseName = dataBase;
            if (dbCon.IsConnect())
            {
                var comm = dbCon.Connection.CreateCommand();
                comm.CommandText = "INSERT INTO `messages`(producer,consumer,message) VALUES(@producer, @consumer, @message)";
                comm.Parameters.AddWithValue("?producer", message.producer);
                comm.Parameters.AddWithValue("?consumer", message.consumer);
                comm.Parameters.AddWithValue("?message", message.message);
                comm.ExecuteNonQuery();
                return true;
            }
            return false;
        }

    }
}
