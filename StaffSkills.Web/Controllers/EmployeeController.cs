﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffSkills.Web.Models;
using StaffSkills.Domain.Model.Entities;
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
            var employees = await _employees.List();
            return Ok(employees);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employees.GetAsync(s => s.Id == id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var employee = new Employee
                {
                    Name = model.Name,
                    PositionId = model.PositionId
                };

                await _employees.InsertAndSaveAsync(employee);
                return Created($"api/employees/{employee.Id}", employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] EmployeeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = await _employees.GetAsync(s => s.Id == id);
            if (employee == null)
                return NotFound();

            try
            {
                if (employee.Name != model.Name)
                    employee.Name = model.Name;

                if (employee.PositionId != model.PositionId)
                    employee.PositionId = model.PositionId;

                await _employees.UpdateAndSaveAsync(employee);
                return Ok(employee);
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
            var employee = await _employees.GetAsync(s => s.Id == id);
            if (employee == null)
                return NotFound();

            try
            {
                await _employees.DeleteAndSaveAsync(employee);
                return Ok(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}