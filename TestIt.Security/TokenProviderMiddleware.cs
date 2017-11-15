using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TestIt.Business;

namespace TestIt.Security
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private readonly IUserService _userService;

        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options, IUserService userService)
        {
            _userService = userService;

            _next = next;
            _options = options.Value;
        }

        public Task Invoke(HttpContext context)
        {
            // If the request path doesn't match, skip
            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
            {
                return _next(context);
            }

            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST")
               || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Bad request.");
            }

            return GenerateToken(context);
        }

        private async Task GenerateToken(HttpContext context)
        {
            var email = context.Request.Form["email"];
            var password = context.Request.Form["password"];

            var identity = await GetIdentity(email, password);
            if (identity == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid email or password.");
                return;
            }

            var now = DateTime.UtcNow;

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64)
            };

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_options.Expiration),
                signingCredentials: _options.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var loggedUser = _userService.GetByEmail(email);
           
            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_options.Expiration.TotalSeconds,
                userId = loggedUser.UserId,
                teacherId = loggedUser.TeacherId,
                studentId = loggedUser.StudentId
            };

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        // IMPORTANT This function is what checks the users credentials and returns the claims they have.
        //
        // In a real-world application, replace the conditional here that returns the ClaimsIdentity with a with a secure system
        // that can you can check the credentials against. An account system hooked to a persisted database and OAuth are good options here.
        private Task<ClaimsIdentity> GetIdentity(string email, string password)
        {
            if (_userService.ValidLogin(email, password))
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(email, "Token"), new Claim[] { }));
            }

            // If the credential check didn't pass, return no claims.
            return Task.FromResult<ClaimsIdentity>(null);
        }

        private static long ToUnixEpochDate(DateTime date) => new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds();
    }
}
