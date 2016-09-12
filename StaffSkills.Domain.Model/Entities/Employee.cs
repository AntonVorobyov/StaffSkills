using System;
using System.Collections.Generic;

namespace StaffSkills.Domain.Model.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }
    }
}
