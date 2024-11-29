using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            AdicionarErros(new ValidarDigitosRgValidator().Validate(this));

            return ValidationResult.IsValid;
        }
    }
}
