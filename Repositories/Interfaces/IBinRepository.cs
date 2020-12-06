using BrighterBins.BE.Models;
using BrighterBins.BE.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Repositories.Interfaces
{
    public interface IBinRepository
    {
        Task<List<Bin>> ReadAllAsync();
        Task<List<Bin>> ReadAllAsync(PagingParams pParams);
        Task<Bin> ReadOneAsync(int id);
        Task<Bin> CreateAsync(Bin bin);
        Task<Bin> UpdateAsync(Bin bin);
        Task DeleteAsync(string id);

        Task<int> GetCount();
    }
}
