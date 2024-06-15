﻿using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.ChangePassword
{
    public class ChangeUserPasswordCommand:IBaseCommand
    {

	private  ChangeUserPasswordCommand()
{
}
        public ChangeUserPasswordCommand(long userId, string currentPassword, string password)
        {
            UserId = userId;
            CurrentPassword = currentPassword;
            Password = password;
        }

        public long UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }

    }
    
}
