using BloggingApp.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloggingApp.Service.Interfaces
{
    public interface IAccountService
    {
        Task<UserRegistrationResponse> RegisterAsync(UserRegistrationRequest request);
        Task<AppUserProfileModel> GetUserProfile(string email);
        Task LogOut();
        Task<AuthenticationResponse> AuthenticationAsync(AuthenticationRequest request);
    }
}
