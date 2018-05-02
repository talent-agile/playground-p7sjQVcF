// { autofold
using System;

namespace Casting
{
// }
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }

        public static implicit operator Vehicle(Car car)
        {
            return null;
        }
        // { autofold
    }
}
// }