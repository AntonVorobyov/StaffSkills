using System.ComponentModel.DataAnnotations;

namespace StaffSkills.Web.Models
{
    public class EmployeeModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int PositionId { get; set; }
    }
}