using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JcmSoft.Domain.Entities.Enums
{
    public enum StatusProjeto
    {
        Cancelado = -1,
        Parado = 0,
        Adiado = 1,
        EmAprovacao = 3,
        EmRevisao = 5,
        Iniciado = 10,
        EmAndamento = 20,
        Concluido = 100
    }
}
