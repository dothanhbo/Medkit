using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IOriginalMedicineRepository OriginalMedicines { get; }
        IDiseaseRepository Diseases { get; }
        IMedicineDiseaseRepository MedicineDisease { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        IUserRepository Users { get; }
        IMedicineRepository Medicines { get; }
        IUsingHistoryRepository UsingHistory { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
