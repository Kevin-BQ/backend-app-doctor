using Data.Interfaces;
using Data.Servicios;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Models.Entidades;
using Microsoft.AspNetCore.Identity;

namespace API.Extensiones
{
    public static class ServicioIdentidadExtension
    {
        public static IServiceCollection AgregarServiciosIdentidad(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityCore<UsuarioAplicacion>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<RolAplicacion>()
                .AddRoleManager<RoleManager<RolAplicacion>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                         options.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateIssuerSigningKey = true,
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                             ValidateIssuer = false,
                             ValidateAudience = false
                         };
                    });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminRol", policy => policy.RequireRole("Admin"));
                opt.AddPolicy("AdminAgendadorRol", policy => policy.RequireRole("Admin", "Agendador"));
                opt.AddPolicy("AdminDoctorRol", policy => policy.RequireRole("Admin", "Doctor"));

            });

            return services;
        }
    }
}
