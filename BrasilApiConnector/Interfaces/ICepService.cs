using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasilApiConnector.Interfaces
{
    public interface ICepService
    {
        Task ProcessCepAsync(string cep);
    }
}
