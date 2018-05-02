using Collections.Exercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using static Collections.Exercises.DictionaryStub;

namespace TechIo
{
    [TestClass]
    public class CollectionsTests
    {
        private bool shouldShowHint = false;
        [TestMethod]
        public void VerifyProcessToKill()
        {
            shouldShowHint = false;
            var r = ListStub.ProcessToKill(new List<string>() { "Explorer.exe", "Teams.exe", "VisualStudio.exe" });
            Assert.AreEqual(true, !r.Contains("Explorer.exe") && r.Count == 2);
            shouldShowHint = false;
        }
        [TestMethod]
        public void VerifyCountByAges()
        {
            shouldShowHint = false;
            List<Employee> employees = new List<Employee>() {
                new Employee("Anna",32),
                new Employee("John",23),
                new Employee("Sarah",23),
                new Employee("Mike",32)
            };

            var r = DictionaryStub.GetEmployeesByAge(employees);
            Assert.AreEqual(true, r.ContainsKey(32) && r.ContainsKey(23) && r[32].Count == 2 && r[23].Count == 2);
            shouldShowHint = false;
        }


        [TestCleanup()]
        public void Cleanup()
        {
            if (shouldShowHint)
            {
                // On Failure
                PrintMessage("Hint 💡", "Did you properly accumulate all stars into 'totalStars'? 🤔");
            }
            else
            {
                // On success
                //if (ExistsInFile(@"/project/target/Exercises/ListStubs.cs", "galaxies.Sum();"))
                //{
                //    PrintMessage("My personal Yoda, you are. 🙏", "* ● ¸ .　¸. :° ☾ ° 　¸. ● ¸ .　　¸.　:. • ");
                //    PrintMessage("My personal Yoda, you are. 🙏", "           　★ °  ☆ ¸. ¸ 　★　 :.　 .   ");
                //    PrintMessage("My personal Yoda, you are. 🙏", "__.-._     ° . .　　　　.　☾ ° 　. *   ¸ .");
                //    PrintMessage("My personal Yoda, you are. 🙏", "'-._\\7'      .　　° ☾  ° 　¸.☆  ● .　　　");
                //    PrintMessage("My personal Yoda, you are. 🙏", " /'.-c    　   * ●  ¸.　　°     ° 　¸.    ");
                //    PrintMessage("My personal Yoda, you are. 🙏", " |  /T      　　°     ° 　¸.     ¸ .　　  ");
                //    PrintMessage("My personal Yoda, you are. 🙏", "_)_/LI");
                //}
                //else
                //{
                //    PrintMessage("Kudos 🌟", "Using Linq, your code could have been shorter. Try it!");
                //    PrintMessage("Kudos 🌟", "");
                //    PrintMessage("Kudos 🌟", "int[] galaxies = {37, 3, 2};");
                //    PrintMessage("Kudos 🌟", "int totalStars = galaxies.Sum(); // 42");
                //}
            }
        }


        /****
            TOOLS
        *****/
        // Display a custom message in a custom channel
        private static void PrintMessage(String channel, String message)
        {
            Console.WriteLine($"TECHIO> message --channel \"{channel}\" \"{message}\"");
        }
        // You can manually handle the success/failure of a testcase using this function
        private static void Success(Boolean success)
        {
            Console.WriteLine($"TECHIO> success {success}");
        }
        // Check the user code looking for a keyword
        private static Boolean ExistsInFile(String path, String keyword)
        {
            return File.ReadAllText(path).Contains(keyword);
        }
    }
}
