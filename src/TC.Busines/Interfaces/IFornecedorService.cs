using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.Busines.Models;

namespace TC.Busines.Interfaces;
public interface IFornecedorService : IDisposable
{
    Task Adicionar(Fornecedor forncedor);
    Task Atualizar(Fornecedor forncedor);
    Task Remover(Guid id);
}
