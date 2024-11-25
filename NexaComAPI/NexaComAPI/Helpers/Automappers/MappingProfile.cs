using App.CommonLayer.DTOModels;
using App.DataAccessLayer.Entities;
using AutoMapper;

namespace NexaComAPI.Helpers.Automappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserRegistrationModel>().ReverseMap(); 
        }
       
    }
}
