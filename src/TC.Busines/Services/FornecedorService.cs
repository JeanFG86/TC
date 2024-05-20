using TC.Busines.Interfaces;
using TC.Busines.Models;
using TC.Busines.Models.Validations;

namespace TC.Busines.Services;
public class FornecedorService : BaseService, IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorService(IFornecedorRepository forncedorRepository, INotificador notificador, IUnitOfWork unitOfWork) 
        : base(notificador, unitOfWork)
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
        
        _fornecedorRepository.Adicionar(forncedor);
        await Commit();
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

        _fornecedorRepository.Atualizar(forncedor);
        await Commit();
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
            _fornecedorRepository.RemoverEnderecoFornecedor(endereco);
        }

        _fornecedorRepository.Remover(id);
        await Commit();
    }

    public void Dispose()
    {
        _fornecedorRepository?.Dispose();
    }
}
