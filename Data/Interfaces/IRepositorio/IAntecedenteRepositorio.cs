using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.IRepositorio
{
    public interface IAntecedenteRepositorio: IRepositorioGenerico<Antecedentes>
    {
        void Actualizar(Antecedentes antecedentes);
    }
}
