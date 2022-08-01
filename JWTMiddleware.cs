using HospitalWebApi.Hospital;
using HospitalWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWebApi
{
    public class JWTMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IRepository _userService;

        public JWTMiddleware(RequestDelegate next, IConfiguration configuration, IRepository userService)
        {
            _next = next;
            _configuration = configuration;
            _userService = userService;
        }

        public async Task Invoke(HttpContext context)
        {
            
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            //next.Invoke(context);
            if (token != null)
                attachAccountToContext(context, token);
            await _next(context);
            
        }

        private void attachAccountToContext(HttpContext context, string token)
        {
            try
            {
                Console.WriteLine("Token-> "+token);
                Console.WriteLine("Context-> " + context);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                Console.WriteLine("TokenHandler-> " + tokenHandler);
                Console.WriteLine("Key-> " + key);
                
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    //ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                Console.WriteLine("validated Token-> " + validatedToken);
                Console.WriteLine("jwtToken-> " + jwtToken);
                var mailId = jwtToken.Claims.First(x => x.Type == "id").Value;
                Console.WriteLine("accountid-> " + mailId);
                // attach account to context on successful jwt validation
                context.Items["Admin"] = _userService.GetAdminDetails(mailId);
            }
            catch
            {
                // do nothing if jwt validation fails
                // account is not attached to context so request won't have access to secure routes
                context.Items["AdminId"] = 1;
            }
        }
    }
}

