using CommomLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IAddressBL
    {
        string AddAddress(AddressModel address);
        string UpdateAddress(AddressModel address);
        List<AddressModel> GetAllAddresses();
        List<AddressModel> GetAddressesbyUserid(int userId);

    }
}
