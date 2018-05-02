using System;
using System.Collections.Generic;
using System.Text;
using Castle.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.Extensions;

namespace Exceptions.Tests
{
    [TestClass]
    public class UserReportTests
    {
        private bool _testFailed;

        private UserReport _userReport;
        private ILog _logger;
        private IUserRepository _userRepository;
        private IFileSystem _fileSystem;

        [TestInitialize]
        public void TestInitialize()
        {
            _logger = Substitute.For<ILog>();
            _userRepository = Substitute.For<IUserRepository>();
            _fileSystem = Substitute.For<IFileSystem>();

            _userReport = new UserReport(_logger, _userRepository, _fileSystem);
        }

        [TestMethod]
        public void CheckThatExceptionsAreLogged()
        {
            _testFailed = true;

            var exception = new Exception();

            _userRepository
                .When(_ => _.GetAllUsers())
                .Do(_ => throw exception);

            Check.ThatCode(() => _userReport.SaveListOfUsers(@"")).Throws<Exception>();
            _logger.Received().LogException(exception);
            
            _testFailed = false;
        }

        [TestMethod]
        public void CheckThatUnauthorizedAccessExceptionsAreHandled()
        {
            _testFailed = true;

            var exception = new UnauthorizedAccessException(@"Access to the path C:\TEMP\Reports\UserReport.txt is denied");

            _userRepository.GetAllUsers().Returns(new List<User>());
            _fileSystem.FileExists(@"").Returns(true);

            _fileSystem
                .When(_ => _.Delete(@""))
                .Do(_ => throw exception);

            Check.ThatCode(() => _userReport.SaveListOfUsers(@""))
                .DoesNotThrow()
                .And.WhichResult().IsFalse();

            _logger.Received().LogException(exception);

            _testFailed = false;
        }

        [TestMethod]
        public void CheckReturnsNewException()
        {
            _testFailed = true;

            var exception = new NullReferenceException("Object reference not set to an instance of an Object");

            _userRepository
                .When(_ => _.GetAllUsers())
                .Do(_ => throw exception);

            Check.ThatCode(() => _userReport.SaveListOfUsers(@""))
                .Throws<InvalidOperationException>()
                .WithMessage("Could not create the report, check logs for more details")
                .And.DueTo<NullReferenceException>();
                
            _logger.Received().LogException(exception);

            _testFailed = false;
        }

        [TestMethod]
        public void CheckAllTogether()
        {
            CheckThatExceptionsAreLogged();
            TestInitialize();
            CheckThatUnauthorizedAccessExceptionsAreHandled();
            TestInitialize();
            CheckReturnsNewException();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_testFailed)
            {
                TechIo.PrintMessage("Hint 💡", "Make sure you catch the right type of exception !");
            }
            else
            {
                TechIo.PrintMessage("Congratulations", "You can proceed to the next chapter");
            }
        }
    }
}
