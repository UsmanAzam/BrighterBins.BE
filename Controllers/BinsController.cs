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
using BrighterBins.BE.Extensions;
using BrighterBins.BE.Utils;

namespace BrighterBins.BE.Controllers
{
    [ApiController]
    [Route("api/bins")]
    public class BinsController : ControllerBase
    {
        private readonly ILogger<BinsController> _logger;
        private readonly IBinRepository _binRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public BinsController(ILogger<BinsController> logger, IMapper mapper, IBinRepository binRepository,
            IMessageRepository messageRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _binRepository = binRepository ?? throw new ArgumentNullException(nameof(binRepository));
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllBinsAsync([FromQuery] PagingParams pageParams = null)
        {
            var response = new PagedResponse<BinViewModel>();

            try
            {
                var bins = await _binRepository.ReadAllAsync(pageParams);
                response.Model =  _mapper.Map<List<BinViewModel>>(bins);
                response.PageNumber = pageParams.PageNumber;
                response.PageSize = pageParams.PageSize;
                response.ItemsCount = await _binRepository.GetCount();
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
        public async Task<IActionResult> GetBinByIdAsync(int id)
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

        [HttpGet("{id}/messages")]
        public async Task<IActionResult> GetMessagesByBinIdAsync(int id)
        {
            var response = new ListResponse<Message>();

            try
            {
                var messages = await _messageRepository.ReadAllByBinIdAsync(id);
                response.Model = messages;

            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = "Server Error";
                response.ErrorDetails = $"{ex.Message}\n{ex.InnerException?.Message}\n{ex.InnerException?.InnerException?.Message}";

            }

            return response.ToHttpResponse();
        }

        [HttpGet("count")]
        public async Task<int> GetBinsCountAsync()
        {
            return await _binRepository.GetCount();
        }
    }
}

