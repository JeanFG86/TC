using TC.Busines.Interfaces;
using TC.Busines.Models;
using TC.Busines.Models.Validations;

namespace TC.Busines.Services;
public class ProdutoService : BaseService, IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador, IUnitOfWork unitOfWork) 
        : base(notificador, unitOfWork)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task Adicionar(Produto produto)
    {
        if(!ExecutarValidacao(new ProdutoValidation(), produto))
            return;
        _produtoRepository.Adicionar(produto);
        await Commit();
    }

    public async Task Atualizar(Produto produto)
    {
        if (!ExecutarValidacao(new ProdutoValidation(), produto))
            return;
        _produtoRepository.Atualizar(produto);
        await Commit();
    }    

    public async Task Remover(Guid id)
    {
        _produtoRepository.Remover(id);
        await Commit();
    }

    public void Dispose()
    {
        _produtoRepository?.Dispose();
    }
}
