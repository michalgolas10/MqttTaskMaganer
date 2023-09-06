namespace MqttTaskMaganer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var ifContinue = true;
            while (ifContinue)
            {
                var host = "0e5a5f6ba4a04040978ca04cbf3169e5.s1.eu.hivemq.cloud";
                var port = 8883;
                var sender = new MqttSender();
                await sender.SendMessage(host, port);
                Console.WriteLine("Do you want to send another message? Press y if Yes");
                var ifContinueMark = Console.ReadKey();
                if (ifContinueMark.KeyChar != 'y')
                {
                    ifContinue = false;
                    Console.Clear();
                    Console.WriteLine("End of the program...");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}