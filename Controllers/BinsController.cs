using BrighterBins.BE.Models;
using BrighterBins.BE.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BinsController : ControllerBase
    {
        private readonly ILogger<BinsController> _logger;
        private readonly IBinRepository _binRepository;

        public BinsController(ILogger<BinsController> logger, IBinRepository binRepository)
        {
            _logger = logger;
            _binRepository = binRepository ?? throw new ArgumentNullException(nameof(binRepository));
        }

        [HttpGet]
        public async Task<List<Bin>> GetAsync()
        {
            return await _binRepository.ReadAllAsync();
        }
    }
}

