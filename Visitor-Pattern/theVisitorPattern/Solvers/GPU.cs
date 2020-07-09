using System;
using Problems;

namespace Solvers
{
    class GPU : ISolver
    {
        static private int MaxTemperature { get; } = 100;
        static private int CPUProblemTemperatureMultiplier { get; } = 3;

        private readonly string model;
        private int temperature;
        private int coolingFactor;

        public GPU(string model, int temperature, int coolingFactor)
        {
            this.model = model;
            this.temperature = temperature;
            this.coolingFactor = coolingFactor;
        }
        private bool DidThermalThrottle()
        {
            if (temperature > MaxTemperature)
            {
                Console.WriteLine($"GPU {model} thermal throttled");
                CoolDown();
                return true;
            }

            return false;
        }

        private void CoolDown()
        {
            temperature -= coolingFactor;
        }

        public void Solve(CPUProblem problem)
        {
            Console.Write($"{model} Attempting to Solve {problem.Name} ...");
            if (temperature <= MaxTemperature)
            {
                Console.Write("Problem Solved");
                problem.makeSolved();

            }
            else
            {
                Console.Write("Failed to Solve - ");
                DidThermalThrottle();
            }
            temperature += problem.RequiredThreads * CPUProblemTemperatureMultiplier;
            Console.WriteLine();
        }

        public void Solve(GPUProblem problem)
        {
            Console.Write($"{model} Attempting to Solve {problem.Name} ...");
            if (temperature <= MaxTemperature)
            {
                Console.Write("Problem Solved ");
                problem.makeSolved();
            }
            else
            {
                Console.Write("Failed to Solve - ");
                DidThermalThrottle();
            }
            Console.WriteLine();
        }

        public void Solve(NetworkProblem problem)
        {
            Console.WriteLine($"{model} cannot solve {problem.Name} - it's a Network Problem");
        }


    }
}