using BusinessLayer.Interfaces;
using CommomLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AddressBL : IAddressBL
    {
        IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }
        public string AddAddress(AddressModel address)
        {
            try
            {
                return this.addressRL.AddAddress(address);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string UpdateAddress(AddressModel address)
        {
            try
            {
                return this.addressRL.UpdateAddress(address);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<AddressModel> GetAllAddresses()
        {
            try
            {
                return this.addressRL.GetAllAddresses();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<AddressModel> GetAddressesbyUserid(int userId)
        {
            try
            {
                return this.addressRL.GetAddressesbyUserid(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
