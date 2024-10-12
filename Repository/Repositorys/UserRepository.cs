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
            UserModel? userSearched = _dbContext.Usuario.FirstOrDefault(x => x.IdUsuario == user.IdUsuario);

            if (userSearched == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                userSearched.Nome = user.Nome;
                userSearched.Sobrenome = user.Sobrenome;
                userSearched.Email = user.Email;
                userSearched.Senha = user.Senha;
                _dbContext.SaveChanges();
                return user;
            }
        }

        public UserModel SearchByEmailAndPassword(string email, string password)
        {
            UserModel? searchedUser = _dbContext.Usuario.FirstOrDefault(x => x.Email == email && x.Senha == password);
            if (searchedUser == null)
            {
                return null;
            }
            else
            {
                return searchedUser;
            }
        }
        public UserModel SearchById(int id)
        {
            UserModel? userSearched = _dbContext.Usuario.FirstOrDefault(x => x.IdUsuario == id);

            if(userSearched == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                return userSearched;
            }
        }

        public bool DeleteUser(int id)
        {
            UserModel? userSearched = _dbContext.Usuario.FirstOrDefault(x => x.IdUsuario == id);

            if (userSearched == null)
            {
                return false;
            }
            else
            {   
                _dbContext.Remove(userSearched);
                _dbContext.SaveChanges();
                return true;
            }
        }
    }
}
