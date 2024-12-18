﻿using Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo.Validators;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;

namespace Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo
{
    public class CadastrarVeiculoCommand : Command
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }

        public override bool IsValid()
        {
            AdicionarErros(new CadastrarVeiculoValidator().Validate(this));

            return ValidationResult.IsValid;
        }
    }
}