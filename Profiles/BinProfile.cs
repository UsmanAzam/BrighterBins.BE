using AutoMapper;
using BrighterBins.BE.Models;
using BrighterBins.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Profiles
{
    public class BinProfile: Profile
    {
        public BinProfile()
        {
            CreateMap<Bin, BinViewModel>();
        }
    }
}
