using SimplesMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesMed.Services.PacienteService
{
    public interface IPaciente
    {
        Task<List<Pacient>> GetAll();

        Task<Pacient> Save(Pacient paciente);

        Task<Pacient> Update(Pacient paciente);
    }
}
