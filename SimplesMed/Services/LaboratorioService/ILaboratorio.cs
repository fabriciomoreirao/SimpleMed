using SimplesMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesMed.Services.LaboratorioService
{
    public interface ILaboratorio
    {
        Task<List<Lab>> GetAll();

        Task<Lab> Save(Lab lab);

        Task<Lab> Update(Lab lab);
    }
}
