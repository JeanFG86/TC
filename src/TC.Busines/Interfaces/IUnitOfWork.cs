namespace TC.Busines.Interfaces;
public interface IUnitOfWork
{
    Task<bool> Commit();
}
