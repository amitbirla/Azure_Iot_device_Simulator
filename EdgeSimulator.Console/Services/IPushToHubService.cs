using EdgeSimulator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeSimulatorConsole.Services
{
    public interface IPushToHubService
    {
        void Create(string DeviceId);

        void Send(List<DeviceData> datas);
    }
}
