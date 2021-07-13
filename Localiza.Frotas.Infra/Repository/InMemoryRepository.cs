using System;
using System.Collections.Generic;
using System.Linq;
using Localiza.Frotas.Domain;

namespace Localiza.Frotas.Infra.Repository
{
    public class InMemoryRepository : IVeiculoRepository
    {
        private readonly IList<Veiculo> entitesVeiculos = new List<Veiculo>();

        public void Add(Veiculo veiculo)
        {
            entitesVeiculos.Add(veiculo);
        }

        public void Delete(Veiculo veiculo)
        {
            entitesVeiculos.Remove(veiculo);
        }

        public void Update(Veiculo veiculo)
        {
            entitesVeiculos.Remove(GetById(veiculo.Id));
            entitesVeiculos.Add(veiculo);
        }

        public Veiculo GetById(Guid id)
        {
            return entitesVeiculos.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Veiculo> GetAll()
        {
            return entitesVeiculos.ToList();
        }
    }
    
}