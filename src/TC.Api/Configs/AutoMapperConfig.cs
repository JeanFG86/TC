using AutoMapper;
using TC.Api.ViewModels;
using TC.Busines.Models;

namespace TC.Api.Configs;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
        CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        CreateMap<ProdutoViewModel, Produto>();

        CreateMap<Produto, ProdutoViewModel>()
            .ForMember(x => x.NomeFornecedor, y => y.MapFrom(j => j.Fornecedor.Nome));
    }
}
