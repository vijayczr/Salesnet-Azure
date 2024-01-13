﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SalesCustom.Services;
using SalesNet.DataEntities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using IAuthenticationService = SalesCustom.Services.IAuthenticationService;

namespace SalesNet.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appsettings;
        public JwtMiddleware(IOptions<AppSettings> appsettings, RequestDelegate next)
        {
            _next = next;
            _appsettings = appsettings.Value;
        }

        public async Task Invoke(HttpContext context, IAuthenticationService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, userService, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IAuthenticationService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var LoginId = jwtToken.Claims.First(x => x.Type == "LoginId").Value;
                // attach user to context on successful jwt validation
                context.Items["Users"] = userService.getProfile(int.Parse(LoginId));
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }

    }
}
