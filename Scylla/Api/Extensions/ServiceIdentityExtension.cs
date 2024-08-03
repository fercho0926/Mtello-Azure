using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Extensions
{
    public static class ServiceIdentityExtension
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration config)
        {
            //MILTON OJO; TRAER DE APPSETTINGS
            var tokenkey = "F79yW2vBGkdxWStEY5TGewtdI5zqVTx7DBYPEKbolf8q41W9DHhtxrJZjE3d6zfp";
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                .AddJwtBearer(options =>
                                    {
                                        options.TokenValidationParameters = new TokenValidationParameters
                                        {

                                            ValidateIssuerSigningKey = true,
                                            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenkey)),
                                            ValidateIssuer = false,
                                            ValidateAudience = false
                                        };
                                    });

            return services;

        }

    }
}
