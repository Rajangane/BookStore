using CommomLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        bool Register(RegisterModel userData);
        public string Login(string emailId, string password);
        public bool ForgetPassword(string email);
        public bool ResetPassword(ResetPassword reset, string email);
    }
}
