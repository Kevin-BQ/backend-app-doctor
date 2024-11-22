using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IDoctorServicio
    {
        Task<IEnumerable<DoctorDto>> ObtenerTodos();
        Task<DoctorDto> Agregar(DoctorDto doctorDto);
        Task Actualizar(DoctorDto doctorDto);
        Task Remover(int id);
    }
}
