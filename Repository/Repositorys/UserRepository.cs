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

        public bool SearchByEmailAndPassword(string email, string password)
        {
            UserModel? searchedUser = _dbContext.Usuario.FirstOrDefault(x => x.Email == email && x.Senha == password);
            if (searchedUser == null)
            {
                bool userFind = false;
                return userFind;
            }
            else
            {
                bool userFind = true;
                return userFind;
            }
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
