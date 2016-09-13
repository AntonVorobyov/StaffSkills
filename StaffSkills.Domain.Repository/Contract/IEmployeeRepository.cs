using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSkills.Domain.Model.Entities;

namespace StaffSkills.Domain.Repository.Contract
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<ICollection<Employee>> List();
    }
}