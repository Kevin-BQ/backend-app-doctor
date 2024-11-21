using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IEspecialidadServicio
    {
        Task<IEnumerable<EspecialidaDto>> ObtenerTodos();
        Task<EspecialidaDto> Agregar(EspecialidaDto especialidaDto);
        Task Actualizar(EspecialidaDto especialidaDto);
        Task Remover(int id);


    }
}
