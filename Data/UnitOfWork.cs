using ExpressVoiture.Interfaces;

namespace ExpressVoiture.Data;

public class UnitOfWork(
    ApplicationDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
    
}
