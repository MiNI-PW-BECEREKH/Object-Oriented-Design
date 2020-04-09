using System;
using Problems;

namespace Solvers
{
    class Ethernet : NetworkDevice
    {
        public Ethernet(string model, int dataLimit) : base(model, dataLimit)
        {
            DeviceType = "Ethernet";
        }

        public override void Solve(NetworkProblem problem)
        {
            Console.Write($"{model} Attempting to Solve {problem.Name} ... ");
            base.Solve(problem);
            Console.WriteLine();
        }
        
    }
}