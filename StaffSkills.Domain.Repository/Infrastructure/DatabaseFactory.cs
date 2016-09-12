using StaffSkills.Domain.Model;
using StaffSkills.Domain.Repository.Contract;

namespace StaffSkills.Domain.Repository.Infrastructure
{
    public class DatabaseFactory : IContextFactory
    {
        private readonly StaffSkillsContext _context;

        public DatabaseFactory(StaffSkillsContext context)
        {
            _context = context;
        }

        public object Get()
        {
            return _context;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}