using MqttTaskManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace MqttTaskMaganer
{
    public class MqttMessage
    {
        public string? Topic { get; set; }
        public string? Message { get; set; }
    }

    public class MqttSender : IMqttSender
    {
        public async Task ConnectToMqttServer(string host, int port, MqttClient client)
        {
            Console.WriteLine("Connecting to" + host + "on port " + port);
            try
            {
                client.Connect(Guid.NewGuid().ToString(), "PowaznaNazwaUzytkownika", "PowazneHaslo.123");
                if (client.IsConnected)
                {
                    Console.WriteLine("Connect Succeful");
                }
                else
                {
                    Console.WriteLine("Connect failed");
                    Environment.Exit(-1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with connection:{ex}");
                Environment.Exit(-1);
            }
        }
        public MqttMessage CreateMqttMessage()
        {
            var ifTopicCorrect = true;
            var ifContentCorrect = true;
            var Topic = string.Empty;
            var Message = string.Empty;
            while (ifTopicCorrect)
            {
                Console.WriteLine("Pass Topic of message:");
                Topic = Console.ReadLine();
                if (string.IsNullOrEmpty(Topic)) Console.WriteLine("Topic can`t be empty! Write Topic again");
                else ifTopicCorrect = false;
            }
            while (ifContentCorrect)
            {
                Console.WriteLine("Pass message content");
                Message = Console.ReadLine();
                if (string.IsNullOrEmpty(Message)) Console.WriteLine("Message content can`t be empty! Write message content again");
                else ifContentCorrect = false;
            }
            return new MqttMessage()
            {
                Message = Message,
                Topic = Topic
            };
        }
        public async Task SendMessage(string host, int port)
        {
            var client = new MqttClient(host, port, true, null, null, MqttSslProtocols.TLSv1_2);
            await ConnectToMqttServer(host, port, client);
            var mqttMessage = CreateMqttMessage();
            try
            {
                client.Publish(mqttMessage.Topic, Encoding.ASCII.GetBytes(mqttMessage.Message));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error with message Publish" + e.Message);
            }
            Console.WriteLine("Message sent succeful");
        }
    }
}
