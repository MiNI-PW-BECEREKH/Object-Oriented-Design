using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            IRandomNumberGenerator generator = new RNG(1337);
            IRandomNumberGenerator another = new RNG(210692);
            IRandomNumberGenerator addition = new Addition(new RNG(1337),5);
            IRandomNumberGenerator multiplication = new Multiplication(new RNG(1337), 2);
            IRandomNumberGenerator somegen = new RNG(42);

            // Add your operations here

            PrintSequence(generator, 10);
            PrintSequence(addition, 10);
            PrintSequence(multiplication, 10);
            multiplication.Reset();
            PrintSequence(new Addition(multiplication, 5), 10);
            multiplication.Reset();
            PrintSequence(new RoundDown(new Addition(multiplication, 5)), 10);
            generator.Reset();
            Console.WriteLine("********");
            PrintSequence(generator, 10);
            PrintSequence(another, 10);
            generator.Reset();
            another.Reset();
            PrintSequence(new Merge(generator, another), 10);

            Console.WriteLine("********");
            generator.Reset();
            another.Reset();
            PrintSequence(generator, 10);
            PrintSequence(another, 10);
            generator.Reset();
            another.Reset();
            PrintSequence(new AlternateMerge(generator, another), 10);
            Console.WriteLine("********");
            generator.Reset();
            another.Reset();
            PrintSequence(generator, 10);
            PrintSequence(another, 10);
            PrintSequence(somegen, 10);
            generator.Reset();
            another.Reset();
            PrintSequence(new AlternateMerge(new RoundDown(new Merge(new Addition(new Multiplication(new Addition(generator,2),3),-2), new Addition(new Multiplication(another,3),5))),new RoundUp(somegen)), 10);
            Console.WriteLine("********");
            generator.Reset();
            PrintSequence(new ClampingFilter(generator,10,30), 10);

            Console.WriteLine("********");
            Console.WriteLine("********");
            generator.Reset();
            PrintSequence(new IncreasingFilter(generator), 10);
            Console.WriteLine("********");
            generator.Reset();
            PrintSequence(generator, 10);
            generator.Reset();

            PrintSequence(new DecreasingFilter(new AlternateMerge(new RoundDown(new Merge(new Addition(new Multiplication(new Addition(generator, 2), 3), -2), new Addition(new Multiplication(another, 3), 5))), new RoundUp(somegen))), 10);

            PrintSequence(new AlternatingFilter(new AlternateMerge(new RoundDown(new Merge(new Addition(new Multiplication(new Addition(generator, 2), 3), -2), new Addition(new Multiplication(another, 3), 5))), new RoundUp(somegen))), 10);


        }

        /**
         * This is just a helper method used for printing generator's numbers.
         * You can use it if you wish so, but it's 100% okay if you ignore it.
         */
        private static void PrintSequence(IRandomNumberGenerator generator, int count) {
            Console.Write("[");
            for(int i = 0; i < count - 1; ++i) {
                Console.Write("{0}, ", generator.Generate());
            }
            Console.WriteLine("{0}]", generator.Generate());
        }
    }
}
