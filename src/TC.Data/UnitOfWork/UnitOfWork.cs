using TC.Busines.Interfaces;
using TC.Data.Context;

namespace TC.Data.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly MeuDbContext _context;

    public UnitOfWork(MeuDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit()
    {
       return await _context.SaveChangesAsync() > 0;
    }
}
