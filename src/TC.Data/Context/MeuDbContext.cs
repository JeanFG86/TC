using Microsoft.EntityFrameworkCore;
using TC.Busines.Models;

namespace TC.Data.Context;
public class MeuDbContext : DbContext
{
    public MeuDbContext(DbContextOptions<MeuDbContext> options): base(options)
    {
        
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
}
