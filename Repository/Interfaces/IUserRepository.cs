using WhatDoYouOwn_ASPNET.Migrations;
using WhatDoYouOwn_ASPNET.Models;

namespace WhatDoYouOwn_ASPNET.Repository.Interfaces
{
    public interface IUserRepository
    {
        UserModel NewUser(UserModel user);
        UserModel EditUser(UserModel user);
        UserModel SearchById(int id);
        bool SearchByEmailAndPassword(string email, string password);
        bool DeleteUser(int id);
    }
}
