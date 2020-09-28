using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy
{
    class RND
    {
        static Random random = new Random(Guid.NewGuid().GetHashCode());

        public static double Double(double minimum, double maximum)
        {
 
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public static int Int(int min , int max)
        {

            return random.Next(min, max);
        }
    }
}
