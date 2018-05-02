using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace Casting.Tests
{
    [TestClass]
    public class CarTests
    {
        private bool _testFailed;

        [TestMethod]
        public void CheckCastingOperators()
        {
            var car = new Car
            {
                Brand = "Toyota",
                Model = "Yaris",
                Year = 2012,
                LicensePlate = "DA-734-PY"
            };

            _testFailed = true;
            Vehicle vehicle = car;
            Check.That(vehicle).IsNotNull();
            Check.That(vehicle.Type).IsEqualTo("Car");
            Check.That(vehicle.Name).IsEqualTo("Toyota / Yaris (2012) / DA-734-PY");
            _testFailed = false;
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_testFailed)
            {
                TechIo.PrintMessage("Hint 💡", "Check that the vehicle name use the proper format");
            }
            else
            {
                TechIo.PrintMessage("Congratulations", "You can move to the next exercise");
            }
        }
    }
}
