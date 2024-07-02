using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawyerApi.Data;
using LawyerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LawyerApi.Repository
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly AppDbContext context;

        public SpecialtyRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Specialty?> GetById(int id)
        {
            return await context.Specialties.FirstOrDefaultAsync(c => c.SpecialtyId == id);
        }

        public async Task<List<Specialty>> GetAll()
        {
            return await context.Specialties.ToListAsync();
        }

        public async Task<int> Create(Specialty specialty)
        {
            context.Add(specialty);
            await context.SaveChangesAsync();
            return specialty.SpecialtyId;
        }

        public async Task<bool> Exist(int id)
        {
            return await context.Specialties.AnyAsync(c=>c.SpecialtyId == id);
        }        

        public async Task Update(Specialty specialty)
        {
            context.Update(specialty);
            await context.SaveChangesAsync();
        }        

        public async Task Delete(int id)
        {
            await context.Specialties.Where(x => x.SpecialtyId == id).ExecuteDeleteAsync();
        }
    }
}