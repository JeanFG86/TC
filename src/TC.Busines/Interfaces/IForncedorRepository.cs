using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.Busines.Models;

namespace TC.Busines.Interfaces;
public interface IForncedorRepository : IRepository<Fornecedor>
{
    Task<Fornecedor> ObterFornecedorEndereco(Guid id);
    Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    Task RemoverEnderecoFornecedor(Endereco endereco);
}
