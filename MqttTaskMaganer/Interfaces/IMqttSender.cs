using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace MqttTaskManager.Interfaces
{
    public interface IMqttSender
    {
        public Task ConnectToMqttServer(string host, int port, MqttClient client);
        public Task SendMessage(string host, int port);
    }
}
