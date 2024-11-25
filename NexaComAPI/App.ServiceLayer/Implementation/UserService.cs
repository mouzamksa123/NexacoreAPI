using App.CommonLayer.DTOModels;
using App.DataAccessLayer.Entities;
using App.ServiceLayer.Interface;
using App.ServiceLayer.IRepository;
using App.ServiceLayer.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App.ServiceLayer.Implementation.UserService;

namespace App.ServiceLayer.Implementation
{
    public class UserService :  GenericRepository<User>, IUserService
    {
        public UserService(ApplicationDbContext context) : base(context)
        {
                
        }
         

    }
}
