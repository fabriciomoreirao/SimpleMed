using SimplesMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesMed.Services.ProfissionalService
{
    public interface IProfissional
    {
        Task<List<Professionals>> GetAll();

        Task<List<Professionals>> Get(string id);

        Task<Professionals> Save(Professionals professionals);

        Task<Professionals> Update(Professionals professionals);

        Task Delete(string id);

    }
}
