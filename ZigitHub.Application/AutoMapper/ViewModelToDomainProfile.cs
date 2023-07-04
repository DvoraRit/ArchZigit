using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZigitHub.Application.ViewModels;
using ZigitHub.Domain.Core.Commands;

namespace ZigitHub.Application.AutoMapper
{
    public class ViewModelToDomainProfile: Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<UserViewModel, CreateUserCommand>()
                .ConstructUsing(c => new CreateUserCommand(c.Full_name, c.Email, c.Is_admin));
        }
    }
}
