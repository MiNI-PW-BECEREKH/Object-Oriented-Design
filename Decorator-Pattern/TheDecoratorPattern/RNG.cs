using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumber
{
    //Closed for modification. don't change this class
    //Concrete Component
    class RNG : IRandomNumberGenerator
    {
        private const int MAX = 100;

        private readonly int seed;
        
        private Random random;

        public RNG(int seed)
        {
            this.seed = seed;
            this.random = new Random(seed);
        }

        public double Generate()
        {
            return Math.Round(random.NextDouble() * MAX, 2);
        }
        
        public void Reset()
        {
            this.random = new Random(this.seed);
        }
    }

    //Abstract Decorator(s)
    abstract class NumberDecorator : IRandomNumberGenerator
    {
        private IRandomNumberGenerator RNG;

        public NumberDecorator(IRandomNumberGenerator rng)
        {
            this.RNG = rng;
        }

        public virtual double Generate()
        {
            return this.RNG.Generate();
        }

        public virtual void Reset()
        {
            this.RNG.Reset();
            return;
        }
    }

    //Concrete Decorators
    internal class Addition : NumberDecorator
    {
        private double Num;
        public Addition(IRandomNumberGenerator rng, double num) : base(rng)
        {
            Num = num;
        }

        public override double Generate()
        {
            return base.Generate() + Num;
        }

        public override void Reset()
        {
            base.Reset();
            return;
        }
    }

    internal class Multiplication : NumberDecorator
    {
        private double Num;

        public Multiplication(IRandomNumberGenerator rng,double num):base(rng)
        {
            Num = num;
        }

        public override double Generate()
        {
            return base.Generate() * Num;
        }

        public override void Reset()
        {
            base.Reset();
            return;
        }
    }

    internal class RoundDown : NumberDecorator
    {
        public RoundDown(IRandomNumberGenerator rng) : base(rng)
        {
        }

        public override double Generate()
        {
            return Math.Floor(base.Generate());
        }

        public override void Reset()
        {
            base.Reset();
            return;
        }
    }

    internal class RoundUp : NumberDecorator
    {
        public RoundUp(IRandomNumberGenerator rng) : base(rng)
        {
        }

        public override double Generate()
        {
            return Math.Ceiling(base.Generate());
        }

        public override void Reset()
        {
            base.Reset();
            return;
        }
    }

    internal class Merge : NumberDecorator
    {
        private IRandomNumberGenerator RND;

        public Merge(IRandomNumberGenerator rng1, IRandomNumberGenerator rng2) : base(rng1)
        {
            RND = rng2;

        }

        public override double Generate()
        {
            double a = base.Generate();
            double b = RND.Generate();
            if (a < b) return b;
            else return a;
        }

        public override void Reset()
        {
            base.Reset();
            return;
        }

    }

    internal class AlternateMerge : NumberDecorator
    {
        private IRandomNumberGenerator RND;
        int i = 0;

        public AlternateMerge(IRandomNumberGenerator rng1, IRandomNumberGenerator rng2) : base(rng1)
        {
            RND = rng2;

        }

        public override double Generate()
        {

            if(i%2 == 0)
            {
                i++;
                return base.Generate();
            }
            else
            {
                i++;
                return RND.Generate();
            }
            
        }

        public override void Reset()
        {
            base.Reset();
            return;
        }
    }

    internal class ClampingFilter : NumberDecorator
    {
        private int lowerBound;
        private int upperBound;

        public ClampingFilter(IRandomNumberGenerator rng,int min,int max):base(rng)
        {
            lowerBound = min;
            upperBound = max;

        }

        public override double Generate()
        {
            double generation = base.Generate();

            if (generation <= upperBound && generation >= lowerBound)
                return generation;
            else if (generation > upperBound)
                return upperBound;
            else
                return lowerBound;
        }

        public override void Reset()
        {
            base.Reset();
            return;
        }

    }

    internal class IncreasingFilter : NumberDecorator
    {
        private double previousgen;

        public IncreasingFilter(IRandomNumberGenerator rng):base(rng)
        {

        }

        public override double Generate()
        {
            double generation = base.Generate();
            
            if(generation >= previousgen )
            {
                previousgen = generation;
                return generation;
            }
            else
            {
                return previousgen;
            }
        }

        public override void Reset()
        {
            base.Reset();
            return;
        }
    }

    internal class DecreasingFilter : NumberDecorator
    {
        private double previousgen;

        public DecreasingFilter(IRandomNumberGenerator rng) : base(rng)
        {
            previousgen = rng.Generate();
        }

        public override double Generate()
        {
            double generation = base.Generate();
            

            if (generation <= previousgen)
            {
                previousgen = generation;
                return generation;
            }
            else
            {
                return previousgen;
            }
        }

        public override void Reset()
        {
            base.Reset();
            return;
        }
    }

    internal class AlternatingFilter : NumberDecorator
    {
        int i = 0;
        public AlternatingFilter(IRandomNumberGenerator rng):base(rng)
        {
            
        }

        public override double Generate()
        {
            double generation = base.Generate();

            if(i%2 == 0)
            {
                i++;
                return generation;
            }
            else
            {
                i++;
                return generation * -1;
            }

        }

    }






}
