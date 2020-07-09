using System;
using Problems;

namespace Solvers
{
    class WiFi : NetworkDevice
    {
        private readonly double packetLossChance;
        private static readonly Random rng = new Random(1597);

        public WiFi(string model, int dataLimit, double packetLossChance) : base(model, dataLimit)
        {
            DeviceType = "WiFi";
            this.packetLossChance = packetLossChance;
        }

        public override void Solve(NetworkProblem problem)
        {
            Console.Write($"{model} Attempting to Solve {problem.Name} ... ");
            if (rng.NextDouble() < packetLossChance)
            {
                base.Solve(problem);
            }
            else
                Console.Write("Failed to Solve");
            Console.WriteLine();
        }
    }
}