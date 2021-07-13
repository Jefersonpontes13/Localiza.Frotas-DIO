using System;
using System.Threading.Tasks;

namespace Localiza.Frotas.Domain
{
    public interface IveiculoDetran
    {
        public Task AgendarVistoriaDetran(Guid veiculoId);
    }
}