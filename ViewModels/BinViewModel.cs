using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.ViewModels
{
    public class BinViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FillLevel { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
