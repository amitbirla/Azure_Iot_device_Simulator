using EdgeSimulatorConsole.DeviceConfiguration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeSimulatorConsole.Services
{
    public class StorageService
    {
        public Simulation Get()
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            workingDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            workingDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            workingDirectory = Path.Combine(workingDirectory, "Config.json");
            var content = File.ReadAllText(workingDirectory);
            Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
            var simulation = Newtonsoft.Json.JsonConvert.DeserializeObject<Simulation>(content);
            return simulation;
        }

        public void Test()
        {
            Simulation simulation = new Simulation();
            simulation.Interval = 5000;
            simulation.Devices = new List<Device>();
            Device device = new Device();
            device.DeviceId = "BITS12345";
            device.Datas = new List<Data>();
            device.Datas.Add(new Data()
            {
                DataKey = "Temperator",
            });
            device.Datas.Add(new Data()
            {
                DataKey = "Humidity",
            });
            simulation.Devices.Add(device);

            Device device1 = new Device();
            device1.DeviceId = "BITS12345";
            device1.Datas = new List<Data>();
            device1.Datas.Add(new Data()
            {
                DataKey = "Temperator",
                MinValue = 10,
                MaxValue = 70
            });
            device1.Datas.Add(new Data()
            {
                DataKey = "Humidity",
                MinValue = 20,
                MaxValue = 50
            });
            simulation.Devices.Add(device1);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(simulation);

            File.AppendAllText("Config.json", json);
        }
    }
}
