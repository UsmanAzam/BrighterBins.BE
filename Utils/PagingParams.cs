using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Utils
{
    public class PagingParams
    {
        [FromQuery(Name = "page_number")]
        public int PageNumber { get; set; }
        [FromQuery(Name = "page_size")]
        public int PageSize { get; set; }
    }
}
