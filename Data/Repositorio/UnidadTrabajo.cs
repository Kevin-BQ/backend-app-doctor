using Data.Interfaces.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _context;
        public IEspecialidadRepositorio Especialidad { get; private set; }
        public IDoctorRespositorio Doctor {  get; private set; }

        public UnidadTrabajo(ApplicationDbContext context)
        {
            _context = context;
            Especialidad = new EspecialidadRepositorio(context);
            Doctor = new DoctorRepositorio(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Guardar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
