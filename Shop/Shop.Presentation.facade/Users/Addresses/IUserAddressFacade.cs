using Common.Application;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteAddress;
using Shop.Application.Users.EditAddress;
using Shop.Application.Users.SetActiveAddress;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Users.Addresses
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddAddress(AddUserAddressCommand command);
        Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);
        Task<OperationResult> EditAddress(EditUserAddressCommand command);
        Task<OperationResult> SetActiveAddress(SetActiveUserAddressCommand command);


        Task<AddressDto> GetById(long userAddressId);
        Task<List<AddressDto>> GetList(long userId);
    }
}
