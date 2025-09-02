using BrasilApiConnector.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasilApiConnector.Interfaces
{
    public interface IApiClient
    {
        Task<BrasilApiCepDto?> GetCepAsync(string cep);
    }
}
