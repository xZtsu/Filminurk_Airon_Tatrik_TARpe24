using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.ApplicationServices.Services
{
    public class AccountsServices : IAccountServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailsServices _emailServices;

        public AccountsServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailsServices emailServices)
        {
            _userManager=userManager;
            _signInManager=signInManager;
            _emailServices=emailServices;
        }
        public async Task<ApplicationUser> Register(ApplicationUserDTO userDTO)
        {
            var user = new ApplicationUser()
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                ProfileType = userDTO.ProfileType,
                DisplayName = userDTO.DisplayName,
            };
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //homework
            }
            return user;
        }
        //homework location
        //public async Task<ApplicationUser> Login(LoginDTO userDTO)
        //{
        //    var user = await _userManager.FindByEmailAsync(userDTO.Email);

        //}
    }
}
