using App.ApplicationLayer.Interface;
using App.CommonLayer.DTOModels;
using App.DataAccessLayer.Entities;
using App.ServiceLayer.Interface;
using App.ServiceLayer.IRepository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;

        private readonly IPasswordHasher _passwordHasher;

        public UserBusiness(IGenericRepository<User> productRepository, IMapper mapper,IPasswordHasher passwordHasher)
        {
            _userRepository = productRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        // Fetches all users and maps them to ProductDto
        public async Task<IEnumerable<UserRegistrationModel>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserRegistrationModel>>(users);
        }

        // Fetches a single product by its Id and maps it to ProductDto
        public async Task<UserRegistrationModel> GetByIdAsync(int id)
        {
            var product = await _userRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null; // Handle null user, e.g., throw exception or return a not found response
            }
            return _mapper.Map<UserRegistrationModel>(product);
        }

        // Creates a new product, maps it, and saves it
        public async Task<UserRegistrationModel> CreateAsync(UserRegistrationModel createUserDto)
        {
            if (createUserDto != null)
            {
                createUserDto.PasswordHash = _passwordHasher.Hash(createUserDto.PasswordHash);
                var user = _mapper.Map<User>(createUserDto);
                var createdUser = await _userRepository.AddAsync(user);
                return _mapper.Map<UserRegistrationModel>(user);
            }
            return new();
        }
    }
}
