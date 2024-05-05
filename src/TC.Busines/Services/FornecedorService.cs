using TC.Busines.Interfaces;
using TC.Busines.Models;
using TC.Busines.Models.Validations;

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
        if(!ExecutarValidacao(new FornecedorValidation(), forncedor) || !ExecutarValidacao(new EnderecoValidation(), forncedor.Endereco))
            return;
        await _fornecedorRepository.Adicionar(forncedor);
    }

    public async Task Atualizar(Fornecedor forncedor)
    {
        if (!ExecutarValidacao(new FornecedorValidation(), forncedor))
            return;
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
