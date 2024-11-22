using BLL.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Net;

namespace API.Controllers
{
    [Authorize(Policy = "AdminAgendadorRol")]
    public class EspecialidadController: BaseApiController
    {
        private readonly IEspecialidadServicio _especialidadServicio;
        private ApiResponse _response;

        public EspecialidadController(IEspecialidadServicio especialidadServicio)
        {
            _especialidadServicio = especialidadServicio;
            _response = new();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _especialidadServicio.ObtenerTodos();
                _response.IsExitoso = true;
                _response.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.statusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(EspecialidaDto especialidaDto)
        {
            try
            {
                await _especialidadServicio.Agregar(especialidaDto);
                _response.IsExitoso = true;
                _response.statusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.statusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(EspecialidaDto especialidaDto)
        {
            try
            {
                await _especialidadServicio.Actualizar(especialidaDto);
                _response.IsExitoso = true;
                _response.statusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.statusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _especialidadServicio.Remover(id);
                _response.IsExitoso = true;
                _response.statusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.statusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

        [HttpGet("ListadoActivos")]
        public async Task<IActionResult> GetActivos()
        {
            try
            {
                _response.Resultado = await _especialidadServicio.ObtenerActivos();
                _response.IsExitoso = true;
                _response.statusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.statusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }
    }
}
