using BrasilApiConnector.Infrastructure.Data;
using BrasilApiConnector.Interfaces;
using BrasilApiConnector.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasilApiConnector.Services
{
    public class CepService : ICepService
    {
        private readonly IApiClient _api;
        private readonly AppDbContext _db; 

        public CepService(IApiClient api, AppDbContext db)
        {
            _api = api;
            _db = db;
            // Aumenta timeout para evitar falhas em tabelas grandes
            _db.Database.SetCommandTimeout(180);
        }

        public async Task ProcessCepAsync(string cep)
        {
            var dto = await _api.GetCepAsync(cep);
            if (string.IsNullOrWhiteSpace(dto?.cep)) return;

            // Consulta rápida para checar existência
            string normalizedCep = dto.cep.Replace("-", "").Trim();
            var exists = await _db.Ceps.AsNoTracking()
                .AnyAsync(c => c.Cep == normalizedCep);
            if (exists) return;

            var entity = new CepInfo
            {
                Cep = dto.cep!,
                State = dto.state,
                City = dto.city,
                Neighborhood = dto.neighborhood,
                Street = dto.street,
                Service = dto.service,
                FetchedAt = DateTime.Now
            };

            _db.Ceps.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task ProcessCepsAsync(IEnumerable<string> ceps)
        {
            // Filtra CEPs válidos
            var cepsList = ceps.Where(c => !string.IsNullOrWhiteSpace(c)).Distinct().ToList();
            if (!cepsList.Any()) return;

            // Buscar todos os CEPs já existentes de uma vez
            var existingCeps = await _db.Ceps
                .Where(c => cepsList.Contains(c.Cep))
                .Select(c => c.Cep)
                .ToListAsync();

            var newEntities = new List<CepInfo>();

            foreach (var cep in ceps)
            {
                if (existingCeps.Contains(cep, StringComparer.OrdinalIgnoreCase)) continue;

                var dto = await _api.GetCepAsync(cep);
                if (string.IsNullOrWhiteSpace(dto?.cep)) continue;

                newEntities.Add(new CepInfo
                {
                    Cep = dto.cep!,
                    State = dto.state,
                    City = dto.city,
                    Neighborhood = dto.neighborhood,
                    Street = dto.street,
                    Service = dto.service,
                    FetchedAt = DateTime.Now
                });
            }

            if (newEntities.Count > 0)
            {
                await _db.Ceps.AddRangeAsync(newEntities);
                await _db.SaveChangesAsync();
            }
        }
    }
}
