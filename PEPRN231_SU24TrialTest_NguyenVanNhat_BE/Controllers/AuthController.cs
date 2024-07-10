using Microsoft.AspNetCore.Mvc;
using PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Service.Interface;
using System.Security.Cryptography;
using System.Text;

namespace PEPRN231_SU24TrialTest_NguyenVanNhat_BE.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> Authenticate(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest("Email cannot be empty");
                }
                if (string.IsNullOrEmpty(password))
                {
                    return BadRequest("Password cannot be empty");
                }
                IActionResult response = Unauthorized();

                

                var customer = await _authService.AuthenticateCustomer(email, password);
                if (customer != null)
                {
                    var accessToken = await _authService.GenerateAccessToken(customer.UserEmail, customer.Role);
                    response = Ok(new { accessToken = accessToken });
                    return response;
                }
                return NotFound("Invalid email or password");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

      
    }
}
