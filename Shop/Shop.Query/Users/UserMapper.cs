using Microsoft.EntityFrameworkCore;
using Shop.Domain.UserAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users
{
    public static class UserMapper
    {
        public static UserDto? Map(this User user)
        {
            if (user == null)
                return null;
            return new UserDto()
            {
                Id = user.Id,
                CreationDate = user.CreationDate,
                Name = user.Name,
                Family = user.Family,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                AvatarName = user.AvatarName,
                IsActive = user.IsActive,
                Gender = user.Gender,
                Password = user.Password,
                Roles = user.Roles.Select(s => new UserRoleDto()
                {
                    RoleId = s.Id,
                    RoleTitle = "",
                }).ToList()
            };
        }
        public static async Task<UserDto> SetUserRoleTitles(this UserDto userDto, ShopContext context)
        {
            var roleIds = userDto.Roles.Select(r=>r.RoleId);
            var result =await context.Roles.Where(s=>roleIds.Contains(s.Id)).ToListAsync();
            var roles=new List<UserRoleDto>();
            foreach(var role in result)
            {
                roles.Add(new UserRoleDto()
                {
                    RoleId = role.Id,
                    RoleTitle = role.Title,
                });
            }
            userDto.Roles = roles;
            return userDto;
        }
        public static UserFilterData MapFilterData(this User user)
        {
            return new UserFilterData()
            {
                Id = user.Id,
                CreationDate = user.CreationDate,
                Name = user.Name,
                Family = user.Family,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                AvatarName = user.AvatarName,
                Gender = user.Gender,
            };
        }
    }
}
