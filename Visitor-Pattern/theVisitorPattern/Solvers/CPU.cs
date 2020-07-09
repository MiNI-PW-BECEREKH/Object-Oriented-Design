using System;
using Problems;

namespace Solvers
{
    //cpu solver 
    class CPU : ISolver
    {
        private readonly string model;
        private readonly int threads;

        public CPU(string model, int threads)
        {
            this.model = model;
            this.threads = threads;
        }

        public void Solve(CPUProblem problem)
        {
            Console.Write($"{model} Attempting to Solve {problem.Name} ...");
            if (this.threads >= problem.RequiredThreads)
            {
                Console.Write("Problem Solved");
                problem.makeSolved();

            }
                
            else
                Console.Write("Failed to Solve");
            Console.WriteLine();
        }

        public void Solve(GPUProblem problem)
        {
            Console.WriteLine($"{model} cannot solve {problem.Name} - it's GPU Problem");
        }

        public void Solve(NetworkProblem problem)
        {
            Console.WriteLine($"{model} cannot solve {problem.Name} - it's a Network Problem");
        }


    }
}