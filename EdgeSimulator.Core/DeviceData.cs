using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeSimulator.Core
{
    [Serializable]
    public class DeviceData
    {
        public Guid Id { get; set; }

        public string DeviceId { get; set; }

        public string DataKey { get; set; }

        public int DataValue { get; set; }

        public DateTime Logged { get; set; }
    }
}
