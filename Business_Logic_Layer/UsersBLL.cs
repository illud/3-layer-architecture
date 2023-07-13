using Business_Logic_Layer.Models;
using System;
using Data_Access_Layer.Repository.Entities;
using Business_Logic_Layer.Services;

namespace Business_Logic_Layer
{
    public class UsersBLL
    {
        private readonly Data_Access_Layer.UsersDAL _DAL;

        public UsersBLL()
        {
            _DAL = new Data_Access_Layer.UsersDAL();
        }

        public async Task<string> CreateUser(UserModel user)
        {
            BcryptService bcryptService = new();

            return await _DAL.Create(new User
            {
                Id = user.Id,
                Age = user.Age,
                Name = user.Name,
                Password = bcryptService.HashPassword(user.Password),
                UserName = user.UserName
            });
        }

        public async Task<string> Login(string userName, string password)
        {
            User userList = await _DAL.GetOneUser(userName);

            //return token if password math
            BcryptService veryfyHash = new();

            if (veryfyHash.VerifyPassword(password, userList.Password))
            {
                JwtService token = new();

                return token.GenerateJwt("user");
            }
            return "Error";
        }

        public async Task<List<UserModel>> GetUsers()
        {
            List<User> personsFromDB = await _DAL.GetAllAsers();
            List<UserModel> users = new();
            
            for(int i = 0; i < personsFromDB.Count; i++)
            {
                users.Add(new UserModel
                {
                    Id = personsFromDB[i].Id,
                    Age = personsFromDB[i].Age,
                    Name = personsFromDB[i].Name,
                    Password = personsFromDB[i].Password,
                    UserName = personsFromDB[i].UserName
                });
            }
            return users.ToList();
        }
    }
}