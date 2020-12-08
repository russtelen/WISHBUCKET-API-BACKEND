using GiftWishlist.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GiftWishlist.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private IConfiguration _config;
        private IServiceProvider _serviceProvider;

        public AuthController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IConfiguration config,
            IServiceProvider serviceProvider)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _serviceProvider = serviceProvider;
        }

        string GenerateJSONWebToken(IdentityUser user)
        {
            var securityKey
                = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT_SITEKEY"]));
            var credentials
                = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var token = new JwtSecurityToken(_config["JWT_ISSUER"],
                _config["JWT_ISSUER"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("Register")]
        public async Task<JsonResult> RegisterAsync([FromBody] RegisterVM registerVM)
        {
            dynamic jsonResponse = new JObject();

            if (!ModelState.IsValid)
            {
                jsonResponse.token = "";
                jsonResponse.status = "Bad request";
                return Json(jsonResponse);
            }

            var user = new IdentityUser { UserName = registerVM.Email, Email = registerVM.Email, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (result.Succeeded)
            {
                return await SignInAsync(new LoginVM() { Email = registerVM.Email, Password = registerVM.Password });
            }

            var errors = result.Errors.Select(e => e.Description);
            jsonResponse.token = "";
            jsonResponse.status = String.Join(',', errors);
            return Json(jsonResponse);
        }

        [HttpPost("Login")]
        public async Task<JsonResult> SignInAsync([FromBody] LoginVM loginVM)
        {
            dynamic jsonResponse = new JObject();

            if (!ModelState.IsValid)
            {
                jsonResponse.token = "";
                jsonResponse.status = "Bad request";
                return Json(jsonResponse);
            }


            var result = await
                _signInManager.PasswordSignInAsync(
                    loginVM.Email.ToUpper(),
                    loginVM.Password,
                    loginVM.RememberMe,
                    lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    jsonResponse.token = tokenString;
                    jsonResponse.status = "OK";
                    return Json(jsonResponse);
                }
            }
            else if (result.IsLockedOut)
            {
                jsonResponse.token = "";
                jsonResponse.status = "Locked Out";
                return Json(jsonResponse);
            }

            jsonResponse.token = "";
            jsonResponse.status = "Invalid Login";
            return Json(jsonResponse);
        }

    }
}

