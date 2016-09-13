using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffSkills.Web.Models;
using StaffSkills.Domain.Model.Entities;
using StaffSkills.Domain.Repository.Contract;

namespace StaffSkills.Web.Controllers
{
    [Route("api/skills")]
    public class SkillController : Controller
    {
        private readonly ISkillRepository _skills;

        public SkillController(ISkillRepository skills)
        {
            _skills = skills;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var skills = await _skills.Query().ToListAsync();
            return Ok(skills);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var skill = await _skills.GetAsync(s => s.Id == id);
            if (skill == null)
                return NotFound();

            return Ok(skill);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SkillModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var skill = new Skill
                {
                    Title = model.Title,
                    PositionId = model.PositionId
                };

                await _skills.InsertAndSaveAsync(skill);
                return Created($"api/skills/{skill.Id}", skill);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] SkillModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var skill = await _skills.GetAsync(s => s.Id == id);
            if (skill == null)
                return NotFound();

            try
            {
                if (skill.Title != model.Title)
                    skill.Title = model.Title;

                if (skill.PositionId != model.PositionId)
                    skill.PositionId = model.PositionId;

                await _skills.UpdateAndSaveAsync(skill);
                return Ok(skill);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _skills.GetAsync(s => s.Id == id);
            if (skill == null)
                return NotFound();

            try
            {
                await _skills.DeleteAndSaveAsync(skill);
                return Ok(skill);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}