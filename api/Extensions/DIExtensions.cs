using api.Data;
using api.EntityFrameworkHelpers;
using api.Identity;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace api.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection collection, IConfiguration config)
        {
            collection.AddControllers();
            collection.AddEndpointsApiExplorer();

            collection.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Jwt Auth header",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "OAuth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            collection.AddAuthentication();
            collection.AddAuthorization(opt =>
            {
                opt.AddPolicy(IdentityData.AdminUserPolicyName, policy =>
                {
                    policy.RequireClaim(IdentityData.AdminUserClaimName, "true");
                });
            });

            collection.ConfigureJWT(config);
            collection.AddCors();
            collection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("SqliteConnection"));
            });
            collection.AddIdentityCore<User>(x =>
            {
                x.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            collection.AddScoped<IUnitOfWork, UnitOfWork>(provider =>
            {
                return new UnitOfWork(provider.GetRequiredService<ApplicationDbContext>());
            });

            collection.AddSingleton<ImageService>();
            collection.AddScoped<AuthService>();
            collection.AddScoped<BasketService>();
            collection.AddScoped<ProductService>();
            collection.AddScoped<CategoriesService>();
            collection.AddScoped<ProductImageService>();

            return collection;
        }

        public static void ConfigureJWT(this IServiceCollection collection, IConfiguration config)
        {
            var jwtSettings = config.GetSection("JwtSettings");

            collection.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("Key").Value!))
                };
            });
        }
    }
}