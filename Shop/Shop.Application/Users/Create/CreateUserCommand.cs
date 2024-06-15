using Common.Application;
using MediatR;
using Shop.Application.Categories.Create;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommand: IBaseCommand
    {
        public CreateUserCommand(string name, string family, string email, string password, string phoneNumber, Gender gender, IUserDomainService _domainService)
        {   Name = name;
            Family = family;
            Email = email;
            Gender = gender;
            Password = password;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
    }

}
