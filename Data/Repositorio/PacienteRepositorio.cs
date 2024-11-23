using Data.Interfaces.IRepositorio;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class PacienteRepositorio : Repositorio<Paciente>, IPacienteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepositorio(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Actualizar(Paciente paciente)
        {
            var pacienteDb = _context.Pacientes.FirstOrDefault(e => e.Id == paciente.Id);

            if (paciente != null)
            {
                pacienteDb.Apellidos = paciente.Apellidos;
                pacienteDb.Nombres = paciente.Apellidos;
                pacienteDb.Estado = paciente.Estado;
                pacienteDb.FechaActualizacion = DateTime.Now;
                pacienteDb.Telefono = paciente.Telefono;
                pacienteDb.Genero = paciente.Genero;
                pacienteDb.ActualizadoPorId = paciente.ActualizadoPorId;
                pacienteDb.Direccion = paciente.Direccion;

                _context.SaveChanges();
            }
        }
    }
}
