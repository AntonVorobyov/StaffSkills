using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StaffSkills.Domain.Model.Entities
{
    public partial class Skill
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PositionId { get; set; }

        [JsonIgnore]
        public virtual Position Position { get; set; }
    }
}
