using EdgeSimulatorConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeSimulatorConsole.Factories
{
    public static class Factory
    {
        static IPushToHubService pushToHubService = null;
        static object obj = new object();

        public static IPushToHubService GetService()
        {
            if (pushToHubService == null)
            {
                lock (obj)
                {
                    if (pushToHubService == null)
                    {
                        pushToHubService = new PushToHubService();
                    }
                }
            }

            return pushToHubService;
        }
    }
}
