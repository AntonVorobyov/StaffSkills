using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffSkills.Domain.Model.Entities;
using StaffSkills.Domain.Repository.Contract;
using StaffSkills.Domain.Repository.Infrastructure;

namespace StaffSkills.Domain.Repository
{
    public class EmployeeRepository : DatabaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IContextFactory factory) : base(factory)
        {
        }

        public async Task<ICollection<Employee>> List()
        {
            return await Select()
                .OrderBy(e => e.Name)
                .Include(e => e.Position)
                .ThenInclude(e => e.Skills)
                .ToListAsync();
        }
    }
}