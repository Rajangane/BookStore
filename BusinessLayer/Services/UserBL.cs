using BusinessLayer.Interfaces;
using CommomLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
   public class UserBL : IUserBL
   {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public bool Register(RegisterModel model)
        {
            try
            {
                return this.userRL.Register(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Login(string EmailId, string Password)
        {
            try
            {
                return this.userRL.Login(EmailId, Password);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ForgetPassword(string email)
        {
            try
            {
                return this.userRL.ForgetPassword(email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ResetPassword(ResetPassword reset, string email)
        {
            try
            {
                return this.userRL.ResetPassword(reset, email);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
