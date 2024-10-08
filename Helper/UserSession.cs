using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;
using WhatDoYouOwn_ASPNET.Models;
using Newtonsoft.Json;

namespace WhatDoYouOwn_ASPNET.Helper
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserSession(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void CreateUserSession(UserModel user)
        {
            string userJson = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("UserSessionLoged", userJson);
        }

        public UserModel GetUserSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("UserSessionLoged");

            if (string.IsNullOrEmpty(userSession))
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<UserModel>(userSession);
            }
                
        }

        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("UserSessionLoged");
        }
    }
}
