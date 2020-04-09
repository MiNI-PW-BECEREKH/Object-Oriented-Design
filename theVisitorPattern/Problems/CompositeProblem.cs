using System;
using System.Collections.Generic;
using System.Linq;
using ResultsCombiners;
using Solvers;



namespace Problems
{
    class CompositeProblem : Problem
    {
        bool fallsolved;

        private readonly IEnumerable<Problem> problems;
        private readonly IResultsCombiner resultsCombiner;
        //IEnumerable<int> Results;

        public CompositeProblem(string name, IEnumerable<Problem> problems,
            IResultsCombiner resultsCombiner) : base(name, () => 0)
        {
            this.problems = problems;
            this.resultsCombiner = resultsCombiner;
        }

        public override void Accept(ISolver solver)
        {
            foreach (var problem in problems)
            {
                if(problem.Solved)
                    continue;
                problem.Accept(solver);
                
            }

            //if all problems solved do the result calcualtion
            foreach (var problem in problems)
            {
                if (problem.Solved == false)
                {
                    fallsolved = false;
                    break;
                }

                fallsolved = true;
            }
            if (fallsolved == true)
                makeSolved(resultsCombiner.CombineResults(Results(problems)));
        }

        public IEnumerable<int> Results(IEnumerable<Problem> problems)
        {
            foreach(var problem in problems )
            {
                if (problem.Solved)
                    yield return problem.Result.Value;
                else
                    break;
            }
        }
    }
}