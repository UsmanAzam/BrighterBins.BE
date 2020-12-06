using BrighterBins.BE.Models;
using BrighterBins.BE.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrighterBins.BE.Extensions;
using BrighterBins.BE.Utils;

namespace BrighterBins.BE.Repositories
{
    public class BinRepository : IBinRepository
    {
        public Task<Bin> CreateAsync(Bin bin)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCount()
        {
            // query database for all items
            return await Task.Run(() =>
            {
                return Database.Bins.Count;
            });
        }

        public async Task<List<Bin>> ReadAllAsync()
        {
            // query database for all items
            return await Task.Run(() =>
            {
                return Database.Bins;
            });
            
        }

        public async Task<List<Bin>> ReadAllAsync(PagingParams pageParams)
        {
            
            // query database for all items
            return await Task.Run(() =>
            {
                return Database.Bins.Page(pageParams.PageNumber, pageParams.PageSize).ToList();
            });
        }

        public async Task<Bin> ReadOneAsync(int id)
        {
            return await Task.Run(() =>
            {
                return Database.Bins.SingleOrDefault(x => x.Id == id);
            });
        }

        public Task<Bin> UpdateAsync(Bin bin)
        {
            throw new NotImplementedException();
        }
    }
}
