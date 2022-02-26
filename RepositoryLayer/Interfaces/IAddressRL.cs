using CommomLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IAddressRL
    {
        string AddAddress(AddressModel address);
        string UpdateAddress(AddressModel address);
        List<AddressModel> GetAllAddresses();
        List<AddressModel> GetAddressesbyUserid(int userId);
    }
}
