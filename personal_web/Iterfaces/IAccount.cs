﻿using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_web.Iterfaces
{
    interface IAccount
    {
        void UpdateProfile(string oldPassword, string newPassword);

        User GetUser(string userName);
    }
}