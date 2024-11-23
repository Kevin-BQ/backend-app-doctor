using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class AntecedenteRepositorio: Repositorio<Antecedentes>, IAntecedenteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public AntecedenteRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Antecedentes antecedente)
        {
            var antecedentedDb = _context.Antecedentes.FirstOrDefault(e => e.Id == antecedente.Id);

            if (antecedente != null)
            {
                antecedentedDb.FechaActualizacion = DateTime.Now;
                antecedentedDb.Observacion = antecedente.Observacion;
                _context.SaveChanges();
            }
        }
    }
}
