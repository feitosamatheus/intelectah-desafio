using ConcessionariaApp.Application.Interfaces;
using ConcessionariaApp.Domain.ValueObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConcessionariaApp.Infrastructure.Services
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;

        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Endereco> BuscarEnderecoPorCep(string cep)
        {
            if (!FormatoValido(cep))
            {
                return null;
            }

            var url = $"https://viacep.com.br/ws/{cep}/json/";
            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);

            var endereco = Endereco.Criar(
                            (string)json["logradouro"],
                            (string)json["localidade"],
                            (string)json["uf"],
                            (string)json["cep"]);
            

            return endereco;
        }

        public async Task<bool> ValidarCep(string cep)
        {
            if (!FormatoValido(cep))
            {
                return false;
            }

            var url = $"https://viacep.com.br/ws/{cep}/json/";
            var response = await _httpClient.GetStringAsync(url);
            var cepResponse = JsonConvert.DeserializeObject<Endereco>(response);

            if (cepResponse?.Cep == null)
            {
                return false; 
            }

            return true;
        }

        private bool FormatoValido(string cep)
        {
            string cleanCep = cep.Replace("-", "").Replace(".", "");

            var regex = new Regex(@"^\d{8}$");
            return regex.IsMatch(cleanCep);
        }
    }
}
