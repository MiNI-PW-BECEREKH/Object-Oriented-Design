using Problems;

namespace Solvers
{
    //visitor interface
    interface ISolver
    {
        //+ Visit() : void
        //void Solve(Problem problem);
        void Solve(CPUProblem problem);
        void Solve(GPUProblem problem);
        void Solve(NetworkProblem problem);

    }
}