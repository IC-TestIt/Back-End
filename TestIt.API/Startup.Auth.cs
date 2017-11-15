using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TestIt.Security;

namespace TestIt.API
{
    public partial class Startup
    {
        private void ConfigureAuth(IApplicationBuilder app)
        {
            // Create the signing key for authentication validation.
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Authentication:SecretKey"]));

            // Create the token validation params for JWT validation.
            var tokenValidationParameters = new TokenValidationParameters
            {
                // Enabling these values causes ASP.NET to validate that the signing key from the client matches the one on the server.
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim.
                ValidateIssuer = true,
                ValidIssuer = Configuration["Authentication:Issuer"],

                // Validate the JWT Audience (aud) claim.
                ValidateAudience = true,
                ValidAudience = Configuration["Authentication:Audience"],

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });

            // Add JWT generation endpoint:
            var options = new TokenProviderOptions
            {
                Audience = Configuration["Authentication:Audience"],
                Issuer = Configuration["Authentication:Issuer"],
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            };

            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
        }
    }
}
