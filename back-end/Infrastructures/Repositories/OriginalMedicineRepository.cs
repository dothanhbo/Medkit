﻿using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.Interfaces.Repositories.Base;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class OriginalMedicineRepository : Repository<OriginalMedicine>, IOriginalMedicineRepository
    {
        public OriginalMedicineRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
