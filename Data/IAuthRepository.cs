﻿using first_web_api.Models;
using System.Threading.Tasks;

namespace first_web_api.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> userExist(string username);

    }
}
