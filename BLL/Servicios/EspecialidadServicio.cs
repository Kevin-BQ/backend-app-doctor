using AutoMapper;
using BLL.Servicios.Interfaces;
using Data.Interfaces.IRepositorio;
using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class EspecialidadServicio : IEspecialidadServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public EspecialidadServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task<EspecialidaDto> Agregar(EspecialidaDto especialidaDto)
        {
            try
            {
                Especialidad especialidad = new Especialidad
                {
                    NombreEspecialidad = especialidaDto.NombreEspecialidad,
                    Descripcion = especialidaDto.Descripcion,
                    Estado = especialidaDto.Estado == 1 ? true : false ,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                };

                await _unidadTrabajo.Especialidad.Agregar(especialidad);
                await _unidadTrabajo.Guardar();
                if(especialidad.Id == 0)
                {
                    throw new TaskCanceledException("La Especialidad no se puedo Crear");
                }
                return _mapper.Map<EspecialidaDto>(especialidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Actualizar(EspecialidaDto especialidaDto)
        {
            try
            {
                var especialidaDb = await _unidadTrabajo.Especialidad.ObtenerPrimero(e => e.Id == especialidaDto.Id);
                if(especialidaDb == null)
                {
                    throw new TaskCanceledException("La especialidad no Existe");
                }

                especialidaDb.NombreEspecialidad = especialidaDto.NombreEspecialidad;
                especialidaDb.Descripcion = especialidaDto.Descripcion;
                especialidaDb.Estado = especialidaDto.Estado == 1 ? true : false;
                _unidadTrabajo.Especialidad.Actualizar(especialidaDb);

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
                var especialidaDb = await _unidadTrabajo.Especialidad.ObtenerPrimero(e => e.Id == id);
                if (especialidaDb == null)
                {
                    throw new TaskCanceledException("La especialidad no Existe");
                }
                _unidadTrabajo.Especialidad.Remover(especialidaDb);
                await _unidadTrabajo .Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<EspecialidaDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Especialidad.ObtenerTodos(
                                    orderBy: e => e.OrderBy(e => e.NombreEspecialidad));

                return _mapper.Map<IEnumerable<EspecialidaDto>>(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<EspecialidaDto>> ObtenerActivos()
        {
            try
            {
                var lista = await _unidadTrabajo.Especialidad.ObtenerTodos(
                                    filtro: e => e.Estado == true,
                                    orderBy: e => e.OrderBy(e => e.NombreEspecialidad));

                return _mapper.Map<IEnumerable<EspecialidaDto>>(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
