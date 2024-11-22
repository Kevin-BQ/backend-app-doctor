using Data.Interfaces.IRepositorio;
using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class DoctorRepositorio : Repositorio<Doctor>, IDoctorRespositorio
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepositorio(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }

        public void Actualizar(Doctor doctor)
        {
            var doctorDb = _context.Doctors.FirstOrDefault(e => e.Id == doctor.Id);

            if (doctor != null)
            {
                doctorDb.Apellidos = doctor.Apellidos;
                doctorDb.Nombres = doctor.Apellidos;
                doctorDb.Estado = doctor.Estado;
                doctorDb.FechaActualizacion = DateTime.Now;
                doctorDb.Telefono = doctor.Telefono;
                doctorDb.Genero = doctor.Genero;
                doctorDb.EspecialidaId = doctor.EspecialidaId;
                doctorDb.Direccion = doctor.Direccion;

                _context.SaveChanges();
            }
        }
    }
}
