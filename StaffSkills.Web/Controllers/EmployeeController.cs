using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffSkills.Domain.Repository.Contract;

namespace StaffSkills.Web.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employees;

        public EmployeeController(IEmployeeRepository employees)
        {
            _employees = employees;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employees.Query().ToListAsync();
            return Ok(employees);
        }
    }
}