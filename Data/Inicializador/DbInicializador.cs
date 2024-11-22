using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Inicializador
{
    public class DbInicializador : IdbInicializador
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UsuarioAplicacion> _userManager;
        private readonly RoleManager<RolAplicacion> _roleManager;

        public DbInicializador(ApplicationDbContext context, UserManager<UsuarioAplicacion> userManager, RoleManager<RolAplicacion> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Inicializar()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate(); // Cuando se ejecuta por primera vez la app y hay migraciones pendientes
                }
            }
            catch (Exception)
            {

                throw;
            }

            // Datos Iniciales
            // Crear Roles
            if (_context.Roles.Any(r => r.Name == "Admin")) return;

             _roleManager.CreateAsync(new RolAplicacion { Name = "Admin" }).GetAwaiter().GetResult();
             _roleManager.CreateAsync(new RolAplicacion { Name = "Agendador" }).GetAwaiter().GetResult();
             _roleManager.CreateAsync(new RolAplicacion { Name = "Doctor" }).GetAwaiter().GetResult();

            // Crear Usuario Administrador
            var usuario = new UsuarioAplicacion
            {
                UserName = "administrador",
                Email = "administrador@gmail",
                Apellidos = "Rojas",
                Nombres = "Jesus"

            };

             _userManager.CreateAsync(usuario, "Admin123").GetAwaiter().GetResult();

            UsuarioAplicacion usuarioAdmin = _context.UsuarioAplicacion.Where(u => u.UserName == "administrador").FirstOrDefault();

            _userManager.AddToRoleAsync(usuarioAdmin, "Admin").GetAwaiter().GetResult();

        }
    }
}
