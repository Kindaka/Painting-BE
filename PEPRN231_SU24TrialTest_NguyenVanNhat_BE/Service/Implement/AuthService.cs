using Microsoft.IdentityModel.Tokens;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Models;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Repository.Interfaces;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Service.Implement
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<UserAccount?> AuthenticateCustomer(string email, string hashedPassword)
        {
            try
            {
                var customer = (await _unitOfWork.UserAccountRepository.FindAsync(a => a.UserPassword == hashedPassword && a.UserEmail == email)).FirstOrDefault();
                if (customer == null)
                {
                    return null;
                }
                else
                {
                    return customer;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> GenerateAccessToken(string email, int? role)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var accessClaims = new List<Claim>
                {
                    new Claim("Email", email),
                    new Claim("Role", role.ToString())

                };
                var accessExpiration = DateTime.Now.AddMinutes(30);
                var accessJwt = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], accessClaims, expires: accessExpiration, signingCredentials: credentials);
                var accessToken = new JwtSecurityTokenHandler().WriteToken(accessJwt);
                return accessToken;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
