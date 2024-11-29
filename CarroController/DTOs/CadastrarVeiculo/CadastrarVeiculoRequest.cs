using System.ComponentModel.DataAnnotations;
using Avaliacao.Microservice.WebAPI.Controllers;

namespace Avaliacao.Microservice.WebAPI.DTOs.CadastrarVeiculo
{
    public class CadastrarVeiculoRequest
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
    }

}
