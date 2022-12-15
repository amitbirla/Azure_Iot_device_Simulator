using EdgeSimulatorConsole.Services;
using System;

namespace EdgeSimulatorConsole
{
    class Program
    {
        static SimulationService simulationService = null;

        static void Main(string[] args)
        {
            var service = new StorageService();
            var simulation = service.Get();
            simulationService = new SimulationService();
            simulationService.Processor(simulation);
            Console.WriteLine("Hello World!");
        }
    }
}
