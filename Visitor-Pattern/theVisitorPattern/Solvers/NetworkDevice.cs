using System;
using Problems;

namespace Solvers
{
    abstract class NetworkDevice : ISolver
    {
        protected string DeviceType { get; set; } = "NetworkDevice";

        protected readonly string model;
        private int dataLimit;

        protected NetworkDevice(string model, int dataLimit)
        {
            this.model = model;
            this.dataLimit = dataLimit;
        }

        public void Solve(CPUProblem problem)
        {
            Console.WriteLine($"{model} cannot solve {problem.Name} - it's a CPU Problem");
        }

        public void Solve(GPUProblem problem)
        {
            Console.WriteLine($"{model} cannot solve {problem.Name} - it's a GPU Problem");
        }

        public virtual void Solve(NetworkProblem problem)
        {
            if(dataLimit <= problem.DataToTransfer)
            {
                Console.Write("Problem Solved");
                problem.makeSolved();

            }
            else
            {
                Console.Write("Failed to Solve");
            }
        }
    }
}