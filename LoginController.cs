using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Vaultex.TransactionHub.UI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/v1")]
    public class CustomerController : Controller
    {
        [HttpGet("[action]")]
        [Route("login")]
        public JwtSecurityToken GetToken(TokenRequest request)
        {

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), $"The '{nameof(request)}' parameter must be provided.");
            }

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return "Could not verify username and password";

            var validDate = DateTime.Now;
            var expiryDate = DateTime.Now.AddDays(1);
            if (request.ExpiryType > 0 && request.ExpiryDuration > 0)
            {
                switch (request.ExpiryType)
                {
                    case 1:
                        expiryDate = DateTime.Now.AddHours(request.ExpiryDuration);
                        break;
                    case 2:
                        expiryDate = DateTime.Now.AddDays(request.ExpiryDuration);
                        break;
                    case 3:
                        expiryDate = DateTime.Now.AddMonths(request.ExpiryDuration);
                        break;
                }
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Username)
            };

            var securityDomain = _configuration.GetSection("Security").GetValue<string>("SecurityDomain");
			SecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Security").GetValue<string>("SecurityKey")));

            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: securityDomain,
                audience: securityDomain,
                claims: claims,
                notBefore: validDate,
                expires: expiryDate,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


        [DataContract]
        public class TokenRequest
        {
            [DataMember(Name = "username")]
            public string Username { get; set; }

            [DataMember(Name = "password")]
            public string Password { get; set; }

            [DataMember(Name = "expiryType")]
            public int ExpiryType { get; set; }

            [DataMember(Name = "expiryDuration")]
            public int ExpiryDuration { get; set; }

        }

    }
}