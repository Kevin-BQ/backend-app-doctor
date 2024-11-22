using AutoMapper;
using BLL.Servicios.Interfaces;
using Data.Interfaces.IRepositorio;
using Data.Repositorio;
using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class DoctorServicio : IDoctorServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public DoctorServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task<DoctorDto> Agregar(DoctorDto doctorDto)
        {
            try
            {
                Doctor doctor = new Doctor
                {
                    Apellidos = doctorDto.Apellidos,
                    Nombres = doctorDto.Nombres,
                    Direccion = doctorDto.Direccion,
                    Telefono = doctorDto.Telefono,
                    Genero = doctorDto.Genero,
                    EspecialidaId = doctorDto.EspecialidaId,
                    Estado = doctorDto.Estado == 1 ? true : false,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                };

                await _unidadTrabajo.Doctor.Agregar(doctor);
                await _unidadTrabajo.Guardar();

                if (doctor.Id == 0)
                {
                    throw new TaskCanceledException("No se puedo agrear un nuevo Doctor");
                }
                return _mapper.Map<DoctorDto>(doctor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Actualizar(DoctorDto doctorDto)
        {
            try
            {
                var doctorDb = await _unidadTrabajo.Doctor.ObtenerPrimero(e => e.Id == doctorDto.Id);

                if (doctorDb == null)
                {
                    throw new TaskCanceledException("El Doctor no Existe");
                }

                doctorDb.Apellidos = doctorDto.Apellidos;
                doctorDb.Nombres = doctorDto.Nombres;
                doctorDb.Estado = doctorDto.Estado == 1 ? true : false;
                doctorDb.Direccion = doctorDto.Direccion;
                doctorDb.Telefono = doctorDto.Telefono;
                doctorDb.Genero = doctorDto.Genero;
                doctorDb.EspecialidaId = doctorDto.EspecialidaId;

                _unidadTrabajo.Doctor.Actualizar(doctorDb);

                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remover(int id)
        {
            try
            {
                var doctorDb = await _unidadTrabajo.Doctor.ObtenerPrimero(e => e.Id == id);

                if (doctorDb == null)
                {
                    throw new TaskCanceledException("El Doctor no Existe");
                }

                _unidadTrabajo.Doctor.Remover(doctorDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<DoctorDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Doctor.ObtenerTodos( incluirPropiedades:"Especialidad",
                                    orderBy: e => e.OrderBy(e => e.Apellidos));

                return _mapper.Map<IEnumerable<DoctorDto>>(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
