using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZigitHub.Application.ViewModels;
using ZigitHub.Domain.Models;

namespace ZigitHub.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
