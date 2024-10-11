using WhatDoYouOwn_ASPNET.Models;

namespace WhatDoYouOwn_ASPNET.Helper
{
    public interface IUserSession
    {
        void CreateUserSession(UserModel user);
        void RemoveUserSession();
        UserModel GetUserSession();
    }
}
