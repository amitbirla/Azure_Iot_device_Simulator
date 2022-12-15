using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeSimulatorConsole.DeviceConfiguration
{
    public class Device
    {
        public string DeviceId { get; set; }

        public bool Enabled { get; set; }

        public List<Data> Datas { get; set; }
    }
}
