using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Helix.SalesService.WebAPI.AuthRegistrations
{
	public static class AuthRegistration
	{
#if !DEBUG
          public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        		{
                    // Check if authentication has already been configured
                    //if (services.Any(x => x.ServiceType == typeof(IAuthenticationService)))
                    //	return services;

                    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:Jwt:IssuerSigningKey"]));

                    // Add Bearer authentication only if it hasn't been configured already
                    services.AddAuthentication(option =>
                    {
                        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                        .AddJwtBearer(option =>
                        {
                            option.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = false,
                                ValidateAudience = false,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = signingKey
                            };
                        });

                    return services;
                }
#endif
	}
}