using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Interfaces.Repositories
{
    public interface IDiaRepository
    {
        Dia GetDiaByParam(Func<Dia, bool> lambdaExpression);
        List<Dia> ListarDias();
    }
}
