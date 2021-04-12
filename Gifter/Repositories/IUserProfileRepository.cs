using System.Collections.Generic;
using Gifter.Models;

namespace Gifter.Repositories
{
    public interface IUserProfileRepository
    {
        List<UserProfile> GetAllUsers();
        void Add(UserProfile user);
        void Update(UserProfile user);
    }
}