using System;
using System.Collections.Generic;

namespace StaffSkills.Domain.Model.Entities
{
    public partial class Position
    {
        public Position()
        {
            Employee = new HashSet<Employee>();
            Skill = new HashSet<Skill>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Skill> Skill { get; set; }
    }
}
