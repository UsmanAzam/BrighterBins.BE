using AutoMapper;
using BrighterBins.BE.Infrastructure;
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
    [Route("api/bins")]
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
        public async Task<IActionResult> GetAllBinsAsync()
        {
            var response = new ListResponse<BinViewModel>();

            try
            {
                var bins = await _binRepository.ReadAllAsync();
                response.Model =  _mapper.Map<List<BinViewModel>>(bins);
                
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "Server Error";
                response.ErrorDetails = $"{ex.Message}\n{ex.InnerException?.Message}\n{ex.InnerException?.InnerException?.Message}";

            }

            return response.ToHttpResponse();
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBinById(string id)
        {
            var response = new SingleResponse<Bin>();

            try
            {
                response.Model = await _binRepository.ReadOneAsync(id); 

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "Server Error";
                response.ErrorDetails = $"{ex.Message}\n{ex.InnerException?.Message}\n{ex.InnerException?.InnerException?.Message}";

            }

            return response.ToHttpResponse();
        }
    }
}

