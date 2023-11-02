using kubestore.DTO;
using kubestore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace kubestore.Services
{
    public class KubeAuthService : IKubeAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        
        public KubeAuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task<AuthMessageResponse> RegisterUserAsync(RegisterVM registerVM)
        {
            if (registerVM.ConfirmPassword != registerVM.Password)
            {
                return new AuthMessageResponse
                {
                    IsSuccess = false,
                    Message = "Passwords Doesn't Match.",
                };
            }

            var identityUser = new IdentityUser
            {
                Email = registerVM.Email,
                UserName = registerVM.Email.Split("@")[0],
            };

            IdentityResult result = await _userManager.CreateAsync(identityUser, registerVM.Password);

            if (result.Succeeded)
            {
                return new AuthMessageResponse
                {
                    IsSuccess = true,
                    Message = "User Creation Successful.",
                };
            }

            return new AuthMessageResponse
            {
                IsSuccess = false,
                Message = "Failed to Create User.",
                Errors = result.Errors.Select(e => e.Description)
            };

        }

        public async Task<AuthMessageResponse> LoginUserAsync(LoginVM loginVM)
        {
            IdentityUser? identityUser = await _userManager.FindByEmailAsync(loginVM.Email);
            if (identityUser == null)
            {
                return new AuthMessageResponse
                {
                    IsSuccess = false,
                    Message = $"No User with {loginVM.Email} Email Found."
                };
            }

            if (await _userManager.CheckPasswordAsync(identityUser, loginVM.Password))
            {
                var userClaims = new[]
                {
                    new Claim("Email", identityUser.Email!),
                    new Claim("UserName", identityUser.UserName!),
                    new Claim("Id", identityUser.Id),
                };

                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:SecurityKey"]!));

                var token = new JwtSecurityToken(
                        issuer: _configuration["AuthSettings:TokenIssuer"],
                        audience: _configuration["AuthSettings:Audience"],
                        claims: userClaims,
                        expires: DateTime.Now.AddDays(7),
                        signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                    );

                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

                await _signInManager.SignInAsync(identityUser, true, tokenAsString);

                return new AuthMessageResponse
                {
                    IsSuccess = true,
                    Message = tokenAsString,
                    Expiry = token.ValidTo
                };
            }

            return new AuthMessageResponse
            {
                IsSuccess = false,
                Message = "Invalid Password."
            };
        }

        public async Task<AuthMessageResponse> LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
            return new AuthMessageResponse
            {
                IsSuccess = true,
                Message = "Logout Successful."
            };
        }

    }
}
