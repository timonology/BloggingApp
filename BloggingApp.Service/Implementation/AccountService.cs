using BloggingApp.Domain.Auth;
using BloggingApp.Domain.Enum;
using BloggingApp.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BloggingApp.Service.Implementation
{
    public class AccountService : IAccountService
    {
        public readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IDateTimeService _dateTimeService;
        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IDateTimeService dateTimeService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dateTimeService = dateTimeService;
        }

        public async Task<UserRegistrationResponse> RegisterAsync(UserRegistrationRequest request)
        {
            var isUserExist = await _userManager.FindByEmailAsync(request.Email);
            if (isUserExist != null)
                return new UserRegistrationResponse() { IsSuccessful = false, Message = "User Already Exist" }; //user already exist

            var newUser = new ApplicationUser()
            {
                Email = request.Email,
                FullName = request.FullName,
                UserName = request.FullName.Split(" ")[0]
            };

            var createdUser = await _userManager.CreateAsync(newUser, request.Password);
            if (!createdUser.Succeeded)
                return new UserRegistrationResponse() { IsSuccessful = false, Message = createdUser.Errors.ToList()[0].Description };

            await _userManager.AddToRoleAsync(newUser, Roles.Basic.ToString());

            return new UserRegistrationResponse() { IsSuccessful = true, Message = "User Successfully Registered" };
        }

        public async Task<AuthenticationResponse> AuthenticationAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return new AuthenticationResponse() { IsSuccessful = false, Message = "User does not exist" };

            var userValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!userValid)
                return new AuthenticationResponse() { IsSuccessful = false, Message = "Incorrect User Credentials" };

            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            
            return new AuthenticationResponse() { IsSuccessful = true, Email = user.Email, Id = user.Id, Roles = rolesList.ToList(), Message = "User Successfully Authenticated" };
        }

        public async Task LogOut() => await _signInManager.SignOutAsync();

        public async Task<AppUserProfileModel> GetUserProfile(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new AppUserProfileModel() { IsSuccessful = false };

            return new AppUserProfileModel() { IsSuccessful = true, Id = user.Id };
        }
    }
}
