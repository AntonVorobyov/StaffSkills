using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaffSkills.Domain.Model.Entities;
using StaffSkills.Domain.Repository.Contract;
using StaffSkills.Web.Models;

namespace StaffSkills.Web.Controllers
{
    [Route("api/positions")]
    public class PositionController : Controller
    {
        private readonly IPositionRepository _positions;

        public PositionController(IPositionRepository positions)
        {
            _positions = positions;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var positions = await _positions.List();
            return Ok(positions);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var position = await _positions.GetAsync(s => s.Id == id);
            if (position == null)
                return NotFound();

            return Ok(position);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PositionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var position = new Position
                {
                    Title = model.Title
                };

                await _positions.InsertAndSaveAsync(position);
                return Created($"api/positions/{position.Id}", position);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] PositionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var position = await _positions.GetAsync(s => s.Id == id);
            if (position == null)
                return NotFound();

            try
            {
                if (position.Title != model.Title)
                    position.Title = model.Title;

                await _positions.UpdateAndSaveAsync(position);
                return Ok(position);
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
            var position = await _positions.GetAsync(s => s.Id == id);
            if (position == null)
                return NotFound();

            try
            {
                await _positions.DeleteAndSaveAsync(position);
                return Ok(position);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}