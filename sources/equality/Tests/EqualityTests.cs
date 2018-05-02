using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace Equality.Tests
{
    [TestClass]
    public class EqualityTests
    {
        private bool _testFailed;

        [TestMethod]
        public void CheckEquals()
        {
            _testFailed = true;

            var first = new User { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1977, 5, 19) };
            var second = new User { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1977, 5, 19) };

            Check.That(first.Equals(null)).IsFalse();
            Check.That(first.Equals(new object())).IsFalse();
            Check.That(first.Equals(second)).IsTrue();

            _testFailed = false;
        }

        [TestMethod]
        public void CheckEqualOperator()
        {
            _testFailed = true;

            var first = new User { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1977, 5, 19) };
            var second = new User { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1977, 5, 19) };

            Check.That(first == second).IsTrue();
            
            _testFailed = false;
        }

        [TestMethod]
        public void CheckGetHashCode()
        {
            _testFailed = true;

            var first = new User { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1977, 5, 19) };
            var second = new User { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1977, 5, 19) };

            Check.That(first.GetHashCode() == second.GetHashCode()).IsTrue();

            _testFailed = false;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_testFailed)
            {
                TechIo.PrintMessage("Hint 💡", "Check your implementation of Equals() and GetHashCode() !");
            }
            else
            {
                TechIo.PrintMessage("Congratulations", "You can proceed to the next chapter");
            }
        }
    }
}
