using System;

namespace Localiza.Frotas.Infra.Facade
{
    public class DetranOptions
    {
        public Guid Id { get; } = Guid.NewGuid();
        
        public string baseUrl { get; set; }
        
        public string VistoriaUrl { get; set; }
        
        public int QuantidadeDiasParaAgendamento { get; set; }
    }
}