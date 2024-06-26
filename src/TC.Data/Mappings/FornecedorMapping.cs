﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TC.Busines.Models;

namespace TC.Data.Mappings;
public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Documento)
            .IsRequired()
            .HasColumnType("varchar(14)");

        // 1 : 1 => Fornecedor : Endereco
        builder.HasOne(p => p.Endereco)
            .WithOne(e => e.Fornecedor);

        // 1 : N => Fornecedor : Produtos
        builder.HasMany(p => p.Produtos)
            .WithOne(p => p.Fornecedor)
            .HasForeignKey(p => p.FornecedorId);

        builder.ToTable("Fornecedores");
    }
}

