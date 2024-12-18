using Avaliacao.Infraestructure.CrossCutting.Common.Entities;
using Avaliacao.Infraestructure.CrossCutting.Common.Enums;
using Avaliacao.Microservice.Domain.Contexts.Alugueis.Dto;

namespace Avaliacao.Microservice.Domain.Contexts.Alugueis
{
    public class Aluguel : Entity
    {
        public int VeiculoId { get; private set; }

        public DateTime DataInicio { get; private set; }

        public DateTime DataFim { get; private set; }

        public DateTime DataDevolucao { get; private set; }

        public decimal Valor { get; private set; }

        public decimal? TaxaAtraso { get; private set; }

        public StatusAluguel Status { get; private set; }

        private const decimal TaxaPorDiaDeAtraso = 0.1m;

        public Avaliacao.Microservice.Domain.Contexts.Veiculos.Veiculo Veiculo { get; set; }

        protected Aluguel()
        { }

        public Aluguel(AlugarVeiculoDTO alugarVeiculoDTO)
        {
            VeiculoId = alugarVeiculoDTO.VeiculoId;
            Valor = alugarVeiculoDTO.Valor;
            DataInicio = alugarVeiculoDTO.DataInicio;
            DataFim = alugarVeiculoDTO.DataFim;
            Status = StatusAluguel.EM_ANDAMENTO;
        }

        public void FinalizarAluguel(DateTime dataDevolucao)
        {
            if (dataDevolucao < DataInicio)
            {
                throw new ArgumentException("Data de devolução não pode ser menor que a data de início do aluguel");
            }

            DataDevolucao = dataDevolucao;

            CalcularTaxaDeAtraso();

            Status = EstaAtrasado() ? StatusAluguel.ATRASADO : StatusAluguel.CONCLUIDO;
        }

        public void CalcularTaxaDeAtraso()
        {
            if (DataDevolucao > DataFim)
            {
                TaxaAtraso = (DataDevolucao - DataFim).Days * TaxaPorDiaDeAtraso;
            }
            else
            {
                TaxaAtraso = 0;
            }
        }

        public bool EstaAtrasado()
        {
            return DataDevolucao > DataFim;
        }

        public bool AtualizarStatus(StatusAluguel status)
        {
            return Status == status;
        }
    }
}