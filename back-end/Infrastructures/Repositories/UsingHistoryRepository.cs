using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Models.DTOs;
using Infrastructure;
using Infrastructure.Repositories.Base;
using Infrastructures.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class UsingHistoryRepository : Repository<UsingHistory>, IUsingHistoryRepository
    {
        public UsingHistoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<UsingHistory>> GetUsingHistoryAsync(Guid id)
        {
            try
            {
                using (var context = new MedkitContext())
                {
                    var usingHistories = await context.Set<UsingHistory>()
                        .Include(x => x.Medicine)
                        .Where(s => s.Medicine.ProductId == id)
                        .ToListAsync();
                    return usingHistories;
                }
            }
            catch (Exception) {
                throw;
            }
            return null;
        }
    }
}
