using System.Collections.Generic;
using System.Threading.Tasks;
using StaffSkills.Domain.Model.Entities;

namespace StaffSkills.Domain.Repository.Contract
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<ICollection<Position>> List();
    }
}