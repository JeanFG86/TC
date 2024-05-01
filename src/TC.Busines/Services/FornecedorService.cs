using TC.Busines.Interfaces;
using TC.Busines.Models;

namespace TC.Busines.Services;
public class FornecedorService : BaseService, IFornecedorService
{
    private readonly IForncedorRepository _fornecedorRepository;

    public FornecedorService(IForncedorRepository forncedorRepository)
    {
        _fornecedorRepository = forncedorRepository;
    }

    public async Task Adicionar(Fornecedor forncedor)
    {
        await _fornecedorRepository.Adicionar(forncedor);
    }

    public async Task Atualizar(Fornecedor forncedor)
    {
        await _fornecedorRepository.Atualizar(forncedor);
    }    

    public async Task Remover(Guid id)
    {
        await _fornecedorRepository.Remover(id);
    }

    public void Dispose()
    {
        _fornecedorRepository?.Dispose();
    }
}
