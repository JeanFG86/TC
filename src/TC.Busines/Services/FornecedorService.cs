using TC.Busines.Interfaces;
using TC.Busines.Models;
using TC.Busines.Models.Validations;

namespace TC.Busines.Services;
public class FornecedorService : BaseService, IFornecedorService
{
    private readonly IForncedorRepository _fornecedorRepository;

    public FornecedorService(IForncedorRepository forncedorRepository, INotificador notificador) : base(notificador)
    {
        _fornecedorRepository = forncedorRepository;
    }

    public async Task Adicionar(Fornecedor forncedor)
    {
        if(!ExecutarValidacao(new FornecedorValidation(), forncedor) || !ExecutarValidacao(new EnderecoValidation(), forncedor.Endereco))
            return;

        if(_fornecedorRepository.Buscar(f => f.Documento == forncedor.Documento).Result.Any())
        {
            Notificar("Já existe um fornecedor com esse documento informado.");
            return;
        }
        
        await _fornecedorRepository.Adicionar(forncedor);
    }

    public async Task Atualizar(Fornecedor forncedor)
    {
        if (!ExecutarValidacao(new FornecedorValidation(), forncedor))
            return;

        if (_fornecedorRepository.Buscar(f => f.Documento == forncedor.Documento && f.Id != forncedor.Id).Result.Any())
        {
            Notificar("Já existe um fornecedor com esse documento informado.");
            return;
        }

        await _fornecedorRepository.Atualizar(forncedor);
    }    

    public async Task Remover(Guid id)
    {
        var fornecedor = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);

        if(fornecedor == null) 
        {
            Notificar("Fornecedor não existe!");
            return;
        }

        if(fornecedor.Produtos.Any())
        {
            Notificar("o fornecedor possui produtos cadastrados!");
            return;
        }

        var endereco = await _fornecedorRepository.ObterEnderecoPorFornecedor(id);

        if(endereco != null)
        {
            await _fornecedorRepository.RemoverEnderecoFornecedor(endereco);
        }

        await _fornecedorRepository.Remover(id);
    }

    public void Dispose()
    {
        _fornecedorRepository?.Dispose();
    }
}
