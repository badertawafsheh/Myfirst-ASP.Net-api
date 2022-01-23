﻿using first_web_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace first_web_api.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            // Search for the user 
            var user = await _context.Users.FirstOrDefaultAsync(x => x.userName.ToLower() == username.ToLower()); // will return null if the user dosent match so next step check if user == null 
            if (user == null)
            {
                response.Success = false;
                response.Messsage = "User Not found ! ";
            }
            else if (!VerfiyPasswordHash(password, user.PasswordHash, user.PasswiordSalt))
            {
                response.Success = false;
                response.Messsage = "Password Incorrect, Try Again ! ";
            }
            else
            {
                response.Data = user.Id.ToString();
            }

            return response;


        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            //Make a hashing for the Password
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await userExist(user.userName))
            {
                response.Success = false;
                response.Messsage = "User Already Exists";
                return response;
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswiordSalt = passwordSalt;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }

        public async Task<bool> userExist(string username)
        {
            if (await _context.Users.AnyAsync(x => x.userName.ToLower().Equals(username.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
        private bool VerfiyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;

            }


        }
    }
}
