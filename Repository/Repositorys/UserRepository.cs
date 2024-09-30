using WhatDoYouOwn_ASPNET.Models;
using WhatDoYouOwn_ASPNET.Repository.Interfaces;

namespace WhatDoYouOwn_ASPNET.Repository.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public UserModel NewUser(UserModel user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public UserModel EditUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public UserModel SearchByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }
        public UserModel SearchById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
