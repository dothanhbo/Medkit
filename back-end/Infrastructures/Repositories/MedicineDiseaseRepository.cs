using Application.Exceptions;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructures.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructures.Repositories
{
    public class MedicineDiseaseRepository : IMedicineDiseaseRepository
    {
        private readonly DbContext _dbContext;
        public MedicineDiseaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<MedicineDisease>> GetMedicinesByDiseaseId(Guid id)
        {
            var MedicineList = await _dbContext.Set<MedicineDisease>()
                .Where(od => od.DiseaseId == id)
                .ToListAsync();
            return MedicineList;
        }
    }
}
