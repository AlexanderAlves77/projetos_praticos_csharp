using BrasilApiConnector.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasilApiConnector.Controllers
{
    public class CepController
    {
        private readonly ICepService _cepService;
        public CepController(ICepService cepService)
        {
            _cepService = cepService;
        }

        public async Task RunAsync()
        {
            var ceps = new[] { "01001000", "30140071", "20040002" };
            foreach (var cep in ceps)
            {
                await _cepService.ProcessCepAsync(cep);
            }
        }
    }
}
