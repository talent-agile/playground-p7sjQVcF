using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace ValueTypes.Tests
{
    [TestClass]
    public class IntFunctionsTests
    {
        private bool _testFailed;

        [TestMethod]
        public void CheckArgumentByReference()
        {
            _testFailed = true;
            Check.That(IntFunctions.ExecuteIncrement(3)).IsEqualTo(4);
            _testFailed = false;
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_testFailed)
            {
                // On Failure
                TechIo.PrintMessage("Hint 💡", "Maybe you should try to pass the argument by reference ? 🤔");
            }
            else
            {
                // On success
                TechIo.PrintMessage("Congratulations", "Continue to the next lesson");
            }
        }
    }
}

