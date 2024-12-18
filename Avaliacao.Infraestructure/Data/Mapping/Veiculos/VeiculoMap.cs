﻿using Avaliacao.Infraestructure.CrossCutting.Common.Enums;
using Avaliacao.Microservice.Domain.Contexts.Veiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avaliacao.Infraestructure.Data.Mapping.Veiculos
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("veiculo");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Modelo)
                .HasColumnName("modelo");

            builder.Property(x => x.Marca)
            .HasColumnName("marca");

            builder.Property(x => x.Cor)
           .HasColumnName("cor");

            builder.Property(x => x.Placa)
                .HasColumnName("placa");

            builder.HasMany(x => x.Alugueis)
                .WithOne(x => x.Veiculo)
                .HasForeignKey(x => x.VeiculoId);

            builder.Property(x => x.FlagStatusVeiculo)
                .HasColumnName("flag_status_veiculo")
                .HasMaxLength(1)
                .IsRequired(true)
                .HasConversion(p => (char)p, p => (StatusVeiculo)p);

            builder.Ignore(x => x.DataUltimaAtualizacao);
            builder.Ignore(x => x.DataCadastro);
        }
    }
}