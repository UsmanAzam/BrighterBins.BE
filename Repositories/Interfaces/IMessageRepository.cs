using BrighterBins.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> ReadAllAsync();
        Task<List<Message>> ReadAllByBinIdAsync(int id);
        Task<Message> ReadOneAsync(int id);
        Task<Message> CreateAsync(Message message);
        Task<Message> UpdateAsync(Message message);
        Task DeleteAsync(string id);
    }
}
