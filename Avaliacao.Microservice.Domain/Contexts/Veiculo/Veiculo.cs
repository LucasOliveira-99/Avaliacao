using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Avaliacao.Infraestructure.CrossCutting.Common.Entities;

namespace Avaliacao.Microservice.Domain.Contexts.Veiculo
{
    public class Veiculo : AggregateRoot
    {
        protected Veiculo() { }

        ///<summary>
        ///Detalhes do veiculo
        ///</summary>
        ///<param modelo="modelo"> modelo do veiculo </param>
        ///<param marca="marca"> marca do veiculo </param>
        ///<param cor="cor"> cor do veiculo </param>
        ///<param placa="placa"> placa do veiculo </param>
        public Veiculo(string modelo, string marca, string cor, string placa)
        {

            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            Placa = placa;
        }

        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public string Marca { get; private set; }
        public string Cor { get; private set; }

    }
}
