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
    }
}