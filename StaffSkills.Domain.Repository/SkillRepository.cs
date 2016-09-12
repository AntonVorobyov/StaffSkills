using StaffSkills.Domain.Model.Entities;
using StaffSkills.Domain.Repository.Contract;
using StaffSkills.Domain.Repository.Infrastructure;

namespace StaffSkills.Domain.Repository
{
    public class SkillRepository : DatabaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(IContextFactory factory) : base(factory)
        {
        }
    }
}