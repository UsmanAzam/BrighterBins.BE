using BrighterBins.BE.Models;
using BrighterBins.BE.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<bool> CreateAsync(User user)
        {
            return await Task.Run(() =>
            {
                user.Id = Database.Users.Count + 1;
                 Database.Users.Add(user);
                return true;
            });
           
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByName(string name)
        {
            return await Task.Run(() =>
            {
                return Database.Users.SingleOrDefault(x => x.Email == name);
            });
        }

        public Task<List<User>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> ReadOneAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
