using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.IRepositorio
{
    public interface IUnidadTrabajo: IDisposable
    {
        IEspecialidadRepositorio Especialidad {  get; }
        IDoctorRespositorio Doctor {  get; }
        IPacienteRepositorio Paciente { get; }
        IHistorialClinicaRepositorio HistorialClinica { get; }
        IAntecedenteRepositorio Antecedente { get; }

        Task Guardar();
    }
}
