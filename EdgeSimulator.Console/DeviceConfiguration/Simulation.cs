using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeSimulatorConsole.DeviceConfiguration
{
    [Serializable]
    public class Simulation
    {
        public int Interval { get; set; }

        public int Rate { get; set; }

        public List<Device> Devices { get; set; }
    }
}
