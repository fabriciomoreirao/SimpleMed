using SimplesMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesMed.Services.UnidadeService
{
    public interface IUnidade
    {
        Task<List<Unidades>> GetAll();

        Task<Unidades> Save(Unidades unidade);

        Task<Unidades> Update(Unidades unidade);
    }
}
