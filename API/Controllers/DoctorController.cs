using BLL.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Net;

namespace API.Controllers
{
    [Authorize(Policy = "AdminAgendadorRol")]
    public class DoctorController: BaseApiController
    {
        private readonly IDoctorServicio _doctorServicio;
        private ApiResponse _response;

        public DoctorController(IDoctorServicio doctorServicio)
        {
            _doctorServicio = doctorServicio;
            _response = new();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _doctorServicio.ObtenerTodos();
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
        public async Task<IActionResult> Crear(DoctorDto doctorDto)
        {
            try
            {
                await _doctorServicio.Agregar(doctorDto);
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
        public async Task<IActionResult> Editar(DoctorDto doctorDto)
        {
            try
            {
                await _doctorServicio.Actualizar(doctorDto);
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
                await _doctorServicio.Remover(id);
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
    }
}
