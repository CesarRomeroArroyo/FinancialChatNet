using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Util;
using RabbitMQ.Client.Events;

namespace Transversal.RabbitMQ
{
    public class rabbitMq
    {
        bot botFinancial = new bot();
        public IConnection GetConnection()
        {
            try
            {
                ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost", Port= 5672 };
                return factory.CreateConnection();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return null;
        }
        public bool send(IConnection con, string message, string friendqueue, string sender)
        {
            try
            {
                IModel channel = con.CreateModel();
                
                
                if(botFinancial.verificateMessage(message))
                {
                    var textToSearch = message.Substring(7, message.Length - 7);
                    var response = botFinancial.makeStookCall(textToSearch);
                    var msg = Encoding.UTF8.GetBytes(response);
                    channel.ExchangeDeclare("messageexchange", ExchangeType.Direct);
                    channel.QueueDeclare(sender, true, false, false, null);
                    channel.QueueBind(sender, "messageexchange", sender, null);
                    channel.BasicPublish("messageexchange", sender, null, msg);

                } else {
                    var msg = Encoding.UTF8.GetBytes(message);
                    channel.ExchangeDeclare("messageexchange", ExchangeType.Direct);
                    channel.QueueDeclare(friendqueue, true, false, false, null);
                    channel.QueueBind(friendqueue, "messageexchange", friendqueue, null);
                    channel.BasicPublish("messageexchange", friendqueue, null, msg);
                }

            }
            catch (Exception)
            {


            }
            return true;

        }
        public string receive(IConnection con, string myqueue)
        {
            try
            {
                string queue = myqueue;
                IModel channel = con.CreateModel();
                channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                BasicGetResult result = channel.BasicGet(queue: queue, autoAck: true);
                if (result != null)
                    return Encoding.UTF8.GetString(result.Body);
                else
                    return null;
            }
            catch (Exception)
            {
                return null;

            }

        }
    }
}
