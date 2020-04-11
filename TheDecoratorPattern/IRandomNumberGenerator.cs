using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumber
{
    //Component
    interface IRandomNumberGenerator
    {
        //generates a random number
        double Generate();
        
        //resets the generator
        void Reset();
    }
}
