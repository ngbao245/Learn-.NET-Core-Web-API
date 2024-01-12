using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CRMCar.Data
{
    public interface IDbContext : IDisposable
    {
        DatabaseFacade DatabaseFacade { get; }
        EntityEntry Add(Object entity);
    }
}
