using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ZigitHub.Domain.Core.Commands;
using ZigitHub.Domain.Interfaces;
using ZigitHub.Domain.Models;

namespace ZigitHub.Domain.Core.CommandsHandlers
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        /// <summary>
        /// this method is called when the command is executed by the bus - every time a user is created
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Full_name = request.Full_Name,
                Email = request.Email,
                Is_admin = request.Is_admin,
                Registration_date = DateTime.Now
            };

            //add to DB
            _userRepository.Add(user);

            return Task.FromResult(true);
        }
    }
}
