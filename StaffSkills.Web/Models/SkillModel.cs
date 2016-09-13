using System.ComponentModel.DataAnnotations;

namespace StaffSkills.Web.Models
{
    public class SkillModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int PositionId { get; set; }
    }
}