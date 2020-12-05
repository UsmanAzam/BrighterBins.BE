using BrighterBins.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Repositories.Interfaces
{
    public interface IBinRepository
    {
        Task<List<Bin>> ReadAllAsync();
        Task<Bin> ReadOneAsync(string id);
        Task<Bin> CreateAsync(Bin bin);
        Task<Bin> UpdateAsync(Bin bin);
        Task DeleteAsync(string id);
    }
}
