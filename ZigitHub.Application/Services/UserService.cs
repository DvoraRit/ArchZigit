using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZigitHub.Application.Interfaces;
using ZigitHub.Application.ViewModels;
using ZigitHub.Domain.Core.Bus;
using ZigitHub.Domain.Core.Commands;
using ZigitHub.Domain.Interfaces;

namespace ZigitHub.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private readonly IMediatorHandler _bus;//MediatR for Domain Events and Notifications
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMediatorHandler bus, IMapper mapper)
        {
            this.userRepository = userRepository;
            this._bus = bus;
            this._mapper = mapper;
        }
        public UserViewModel GetUsers()
        {
            return new UserViewModel
            {
                Users = this.userRepository.GetUsers()
            };
        }

        public void Create(UserViewModel userViewModel)
        {
     
            //send the command to the bus
            _bus.SendCommand(_mapper.Map<CreateUserCommand>(userViewModel));

        }

    }
}
