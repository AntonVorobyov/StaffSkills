using System;
using System.Collections.Generic;

namespace StaffSkills.Domain.Model.Entities
{
    public partial class Skill
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }
    }
}
