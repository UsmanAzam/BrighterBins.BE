using BrighterBins.BE.Models;
using BrighterBins.BE.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public Task<Message> CreateAsync(Message message)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Message>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Message>> ReadAllByBinIdAsync(int id)
        {
            // query database for all items
            return await Task.Run(() =>
            {
                return Database.Bins.SingleOrDefault(x => x.Id == id).Messages;
            });
        }

        public Task<Message> ReadOneAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Message> UpdateAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
