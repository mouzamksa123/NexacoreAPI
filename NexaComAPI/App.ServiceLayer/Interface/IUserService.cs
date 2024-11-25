using App.CommonLayer.DTOModels;
using App.DataAccessLayer.Entities;
using App.ServiceLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ServiceLayer.Interface
{
    public interface IUserService : IGenericRepository<User>
    {
        
    }
}
