using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public UserService(IUserRepository userRepository, IMediatorHandler bus)
        {
            this.userRepository = userRepository;
            this._bus = bus;
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
            //before we use the bus to send a message, it needs to be a type of command.
            var createUserCommand = new CreateUserCommand(
                userViewModel.Full_name,
                userViewModel.Email,
                userViewModel.Is_admin
                );

            //send the command to the bus
            _bus.SendCommand(createUserCommand);

        }

    }
}
