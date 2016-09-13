using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffSkills.Domain.Model.Entities;
using StaffSkills.Domain.Repository.Contract;
using StaffSkills.Domain.Repository.Infrastructure;

namespace StaffSkills.Domain.Repository
{
    public class PositionRepository : DatabaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(IContextFactory factory) : base(factory)
        {
        }

        public async Task<ICollection<Position>> List()
        {
            return await Select().Include(p => p.Skills).ToListAsync();
        }
    }
}