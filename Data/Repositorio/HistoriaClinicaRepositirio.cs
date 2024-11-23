using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class HistoriaClinicaRepositirio: Repositorio<HistoriaClinica>, IHistorialClinicaRepositorio
    {
        private readonly ApplicationDbContext _context;

        public HistoriaClinicaRepositirio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(HistoriaClinica historiaClinica)
        {
            var historiaClinicaDb = _context.HistoriaClinicas.FirstOrDefault(e => e.Id == historiaClinica.Id);

            if (historiaClinica != null)
            {
                historiaClinicaDb.FechaCreacion = DateTime.Now;

                _context.SaveChanges();
            }
        }
    }
}
