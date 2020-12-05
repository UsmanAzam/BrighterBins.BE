using BrighterBins.BE.Models;
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

        public BinsController(ILogger<BinsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Bin> Get()
        {
            return Database.Bins;
        }
    }
}
