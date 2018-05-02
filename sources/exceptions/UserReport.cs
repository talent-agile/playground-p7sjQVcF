// { autofold
using System;
using System.Linq;

namespace Exceptions
{
    public class UserReport
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileSystem _fileSystem;

        public UserReport(ILog logger, IUserRepository userRepository, IFileSystem fileSystem)
        {
            _logger = logger;
            _userRepository = userRepository;
            _fileSystem = fileSystem;
        }
// }
        private readonly ILog _logger;

        public bool SaveListOfUsers(string filePath)
        {
            var allUsers = _userRepository.GetAllUsers();

            var exportData = string.Join(Environment.NewLine, allUsers.Select(user => $"{user.FirstName} {user.LastName}"));

            if (_fileSystem.FileExists(filePath))
            {
                _fileSystem.Delete(filePath);
            }

            _fileSystem.WriteAllLines(filePath, exportData);

            return true;
        }
// { autofold
    }
}
// }
