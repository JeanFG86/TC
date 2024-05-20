﻿using Microsoft.EntityFrameworkCore;
using TC.Busines.Interfaces;
using TC.Busines.Models;
using TC.Data.Context;

namespace TC.Data.Repository;
public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
{
    public FornecedorRepository(MeuDbContext context) : base(context) { }

    public async Task<Fornecedor?> ObterFornecedorEndereco(Guid id)
    {
        return await Db.Fornecedores.AsNoTracking()
            .Include(c => c.Endereco)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Fornecedor?> ObterFornecedorProdutosEndereco(Guid id)
    {
        return await Db.Fornecedores.AsNoTracking()
            .Include(c => c.Produtos)
            .Include(c => c.Endereco)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Endereco?> ObterEnderecoPorFornecedor(Guid fornecedorId)
    {
        return await Db.Enderecos.AsNoTracking()
            .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
    }

    public void RemoverEnderecoFornecedor(Endereco endereco)
    {
        Db.Enderecos.Remove(endereco);
    }
}

