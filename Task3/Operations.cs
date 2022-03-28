using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    delegate decimal Operation(decimal x, decimal y);
    internal class Operations
    {
        public Operation mul = (x, y) => x * y;
        public Operation div = (x, y) =>
        {
            if (y != 0)
            {
                return x / y;
            }
            else
                throw new Exception("Ділення на нуль не можливе");
        };

        public Operation sum = (x, y) => x + y;
        public Operation sub = (x, y) => x - y;
    }
}
