using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public static class AddJwtTokenServicesExtensions
    {
        public static void AddJwtTokenServices(this IServiceCollection Services, IConfiguration configuration)
        {

            //agregar add config 
            var bindJwtConfig = new JwtSettings();

            configuration.Bind("JsonWebTokenKeys", bindJwtConfig);

            // agregar singleton 
            Services.AddSingleton(bindJwtConfig);

            Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = bindJwtConfig.ValidateIssuerSgningKey,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtConfig.IssueSigningKey)),
                        ValidateIssuer = bindJwtConfig.ValidateIssuer,
                        ValidIssuer = bindJwtConfig.ValidIssuer,
                        ValidateAudience = bindJwtConfig.ValidateAudience,
                        ValidAudience = bindJwtConfig.ValidAudience,
                        RequireExpirationTime = bindJwtConfig.ValidateLifeTime,
                        ClockSkew = TimeSpan.FromDays(1),

                    };

                });

        }

    }
}
