using Data.Interfaces.IRepositorio;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class EspecialidadRepositorio : Repositorio<Especialidad>, IEspecialidadRepositorio
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadRepositorio(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }

        public void Actualizar(Especialidad especialidad)
        {
            var especialidadDb = _context.Especialidades.FirstOrDefault(e => e.Id == especialidad.Id);
            if (especialidad != null)
            {
                especialidadDb.NombreEspecialidad = especialidad.NombreEspecialidad;
                especialidadDb.Descripcion = especialidad.Descripcion;
                especialidad.Estado = especialidadDb.Estado;
                _context.SaveChanges();
            }
        }
    }
}
