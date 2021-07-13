using System;
using System.Collections.Generic;

namespace Localiza.Frotas.Domain
{
    public interface IVeiculoRepository
    {
        void Add(Veiculo veiculo);
        void Delete(Veiculo veiculo);
        void Update(Veiculo veiculo);
        Veiculo GetById(Guid id);
        IEnumerable<Veiculo> GetAll();
    }
}