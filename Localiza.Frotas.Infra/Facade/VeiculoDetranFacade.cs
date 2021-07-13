using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Localiza.Frotas.Domain;
using Microsoft.Extensions.Options;

namespace Localiza.Frotas.Infra.Facade
{
    public class VeiculoDetranFacade : IveiculoDetran
    {
        private readonly DetranOptions _detranOptions;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IVeiculoRepository _veiculoRepository;
        
        public VeiculoDetranFacade(
            IOptionsMonitor<DetranOptions> optionsMonitor, 
            IHttpClientFactory httpClientFactory,
            IVeiculoRepository veiculoRepository)
        {
            this._detranOptions = optionsMonitor.CurrentValue;
            this._httpClientFactory = httpClientFactory;
            this._veiculoRepository = veiculoRepository;
        }
        
        public async Task AgendarVistoriaDetran(Guid veiculoId)
        {
            var veiculo = _veiculoRepository.GetById(veiculoId);
            var requestModel = new VistoriaModel()
            {
                Placa = veiculo.Placa,
                AgendadoPara = DateTime.Now.AddDays(_detranOptions.QuantidadeDiasParaAgendamento)
            };

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_detranOptions.baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var jsonContent = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await client.PostAsync(_detranOptions.VistoriaUrl, contentString);
        }
    }
}