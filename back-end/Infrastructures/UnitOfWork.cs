using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Repositories.Base;
using Infrastructure.Repositories;
using Infrastructures.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructures.Repositories;
using Microsoft.Extensions.Options;
using Domain.Interfaces.Services;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public IOriginalMedicineRepository OriginalMedicines => _originalMedicine ?? (_originalMedicine = new OriginalMedicineRepository(dbContext));

        private IOriginalMedicineRepository _originalMedicine;
        public IDiseaseRepository Diseases => _disease ?? (_disease = new DiseaseRepository(dbContext));

        private IDiseaseRepository _disease;
        public IMedicineDiseaseRepository MedicineDisease => _medicineDisease ?? (_medicineDisease = new MedicineDiseaseRepository(dbContext));

        private IMedicineDiseaseRepository _medicineDisease;
        public IOrderRepository Orders => _order ?? (_order = new OrderRepository(dbContext));

        private IOrderRepository _order;
        public IProductRepository Products => _product ?? (_product = new ProductRepository(dbContext));

        private IProductRepository _product;
        public IUserRepository Users => _user ?? (_user = new UserRepository(dbContext));

        private IUserRepository _user;
        public IMedicineRepository Medicines => _medicine ?? (_medicine = new MedicineRepository(dbContext));

        private IMedicineRepository _medicine;
        public IUsingHistoryRepository UsingHistory => _usingHistory ?? (_usingHistory = new UsingHistoryRepository(dbContext));

        private IUsingHistoryRepository _usingHistory;

        private bool disposed = false;


        public UnitOfWork()
        {
            dbContext = new MedkitContext();
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();
            Dispose(false);
            GC.SuppressFinalize(this);
        }
        protected virtual async ValueTask DisposeAsyncCore()
        {
            await dbContext.DisposeAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                dbContext.Dispose();
            }
            disposed = true;
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
