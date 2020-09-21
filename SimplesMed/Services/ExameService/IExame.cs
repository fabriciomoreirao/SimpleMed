using SimplesMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesMed.Services.ExameService
{
    public interface IExame
    {
        Task<List<Exam>> GetAll();

        Task<Exam> Save(Exam exame);

    }
}
