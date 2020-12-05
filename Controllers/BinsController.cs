using AutoMapper;
using BrighterBins.BE.Models;
using BrighterBins.BE.Repositories.Interfaces;
using BrighterBins.BE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Controllers
{
    [ApiController]
    [Route("bins")]
    public class BinsController : ControllerBase
    {
        private readonly ILogger<BinsController> _logger;
        private readonly IBinRepository _binRepository;
        private readonly IMapper _mapper;

        public BinsController(ILogger<BinsController> logger, IMapper mapper, IBinRepository binRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _binRepository = binRepository ?? throw new ArgumentNullException(nameof(binRepository));
        }

        [HttpGet]
        public async Task<List<BinViewModel>> GetAsync()
        {
            var bins =  await _binRepository.ReadAllAsync();
            return  _mapper.Map<List<BinViewModel>>(bins);
        }
    }
}

