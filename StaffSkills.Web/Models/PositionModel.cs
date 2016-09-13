using System.ComponentModel.DataAnnotations;

namespace StaffSkills.Web.Models
{
    public class PositionModel
    {
        [Required]
        public string Title { get; set; }
    }
}