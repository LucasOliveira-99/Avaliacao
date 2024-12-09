using Avaliacao.Microservice.Domain.Contexts.Alugueis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avaliacao.Infraestructure.Data.Mapping.Alugueis
{
    public class AluguelMap : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("aluguel");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.VeiculoId)
             .HasColumnName("veiculoid");


            builder.Property(x => x.DataInicio)
                .HasColumnName("datainicio");

            builder.Property(x => x.DataFim)
            .HasColumnName("datafim");

            builder.Property(x => x.DataDevolucao)
           .HasColumnName("datadevolucao");

            builder.Property(x => x.Valor)
                .HasColumnName("valor");

            builder.Property(x => x.TaxaAtraso)
                .HasColumnName("taxaatraso");

            builder.Property(x => x.Status)
                .HasColumnName("status");

            builder.HasOne(x => x.Veiculo)
                .WithMany(x => x.Alugueis)
                .HasForeignKey(x => x.VeiculoId);

            builder.Ignore(x => x.DataUltimaAtualizacao);
            builder.Ignore(x => x.DataCadastro);
        }
    }
}