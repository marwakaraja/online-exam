using McqExaminationSystem.DataTransferObjectsManagers.UserDtosManager;
using McqExaminationSystem.DataTransferObjectsManagers.UserDtosManager.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace McqExaminationSystem.Controllers
{
    [Route("api/login")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IUserDtosManager userDtosManager;

        public LoginController(IUserDtosManager userDtosManager)
            => this.userDtosManager = userDtosManager;

        [HttpPost]
        public IActionResult AuthenticateLogger(UserCredentialsDto userCredentialsDto)
        {
            var user = userDtosManager.GetUserDtoByUserCredentials(userCredentialsDto);

            if (user != null)
            {
                // Start making an authentication token for this user, then returning it with an appropriate status code:

                // First: Define identity claims for this user.
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.SerialNumber, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                // Second: Construct an encoded secret key for this token.
                string secretKey = "McqExaminationSystemProjectVersion1.0";
                var encodedSecretKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(secretKey));

                // Third: Construct the token itself.
                var signingCredentials = new SigningCredentials(
                    encodedSecretKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    signingCredentials: signingCredentials,
                    expires: DateTime.Now.AddDays(1));

                var tokenStringified = new JwtSecurityTokenHandler().WriteToken(token);

                // Fourth: Return the constructed token, with an appropriate status code.
                return Ok(new {token = tokenStringified });
            }

            return Unauthorized();
        }
    }
}
