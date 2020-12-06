using BrighterBins.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> ReadAllAsync();

        Task<User> FindByName(string name);
        Task<User> ReadOneAsync(int id);
        Task<bool> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(string id);
    }
}
