using EdgeSimulator.Core;
using EdgeSimulatorConsole.DeviceConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdgeSimulatorConsole.Services
{
    public class SimulationService
    {
        bool IsProcess = true;

        public void Processor(Simulation simulation)
        {
            foreach (var device in simulation.Devices)
            {
                //Factories.Factory.GetService().Create(device.DeviceId);
            }

            while (IsProcess)
            {
                Console.WriteLine();

                List<DeviceData> deviceDatas = new List<DeviceData>();
                foreach (var device in simulation.Devices)
                {
                    if (device.Enabled)
                    {
                        foreach (var data in device.Datas)
                        {
                            if (data.Enabled)
                            {
                                DeviceData deviceData = new DeviceData();
                                deviceData.DeviceId = device.DeviceId;
                                deviceData.DataKey = data.DataKey;
                                deviceData.DataValue = data.GetValue();
                                deviceData.Logged = DateTime.UtcNow;
                                deviceData.Id = Guid.NewGuid();
                                deviceDatas.Add(deviceData);
                            }
                        }
                    }
                }

                Factories.Factory.GetService().Send(deviceDatas);

                Thread.Sleep(simulation.Interval);
            }
        }
    }
}
