using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using EdgeSimulatorConsole.DeviceConfiguration;
using Newtonsoft.Json;
using EdgeSimulator.Core;
using Microsoft.Azure.Devices;

namespace EdgeSimulatorConsole.Services
{
    public class PushToHubService : IPushToHubService
    {
        static Dictionary<string, DeviceClient> connection = new Dictionary<string, DeviceClient>();
        static string hubConnectionString = "<ADD IOTHUB CONNECTIONSTRING HERE>";
        static RegistryManager registryManager = null;
        
        static PushToHubService()
        {
            registryManager = RegistryManager.CreateFromConnectionString(hubConnectionString);
        }

        public void Create(string DeviceId)
        {
            DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(hubConnectionString, DeviceId, Microsoft.Azure.Devices.Client.TransportType.Mqtt);
            //deviceClient.OpenAsync().GetAwaiter().GetResult();
            connection.Add(DeviceId, deviceClient);

            var device = new Microsoft.Azure.Devices.Device(DeviceId);
            var deviceRegistry = registryManager.GetDeviceAsync(DeviceId).GetAwaiter().GetResult();
            if (deviceRegistry == null)
                registryManager.AddDeviceAsync(device).GetAwaiter().GetResult();
        }

        public void Send(List<DeviceData> datas)
        {
            foreach (var data in datas)
            {
                if (!connection.ContainsKey(data.DeviceId))
                {
                    Create(data.DeviceId);
                }
            }

            foreach (var data in datas)
            {
                var client = connection[data.DeviceId];


                //var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
                var message = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
                message.MessageId = Guid.NewGuid().ToString();

                client.SendEventAsync(message).GetAwaiter().GetResult();
                Console.WriteLine($"DeviceData {JsonConvert.SerializeObject(data)} Sent to hub Successfully");
            }
        }
    }
}
