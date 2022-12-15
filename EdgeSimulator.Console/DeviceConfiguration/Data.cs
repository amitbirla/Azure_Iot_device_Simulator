using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeSimulatorConsole.DeviceConfiguration
{
    public class Data
    {
        Random random = new Random();

        public string DataKey { get; set; }

        public int MinValue { get; set; } = 0;

        public int MaxValue { get; set; } = 100;

        public bool Enabled { get; set; } = true;

        public int GetValue()
        {
            return random.Next(MinValue, MaxValue);
        }
    }
}
