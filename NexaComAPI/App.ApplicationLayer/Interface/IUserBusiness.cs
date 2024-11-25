using App.CommonLayer.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Interface
{
    public interface IUserBusiness
    {
        Task<IEnumerable<UserRegistrationModel>> GetAllAsync();
        Task<UserRegistrationModel> GetByIdAsync(int id);
        Task<UserRegistrationModel> CreateAsync(UserRegistrationModel createProductDto);


    }
}
