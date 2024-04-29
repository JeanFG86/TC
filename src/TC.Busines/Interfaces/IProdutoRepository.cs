using TC.Busines.Models;

namespace TC.Busines.Interfaces;
public interface IProdutoRepository : IRepository<Produto>
{
    Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
    Task<IEnumerable<Produto>> ObterProdutosFornecedores();
    Task<Produto> ObterProdutoFornecedor(Guid id);
}
