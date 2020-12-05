using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Models
{
    public class Bin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int FillLevel { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public List<Message> Messages { get; set; }

        public Bin()
        {
            Messages = new List<Message>();
        }

    }
}
