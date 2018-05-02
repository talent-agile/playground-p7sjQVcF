using System.Collections.Generic;

namespace Exceptions
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
    }
}