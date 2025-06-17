using ApiCrudProject.Data;
using ApiCrudProject.Models;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiCrudProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly AppDbContext _Context;
        public StudentController(AppDbContext context)                                                                                            
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsDetails>>>GetPeople()
        {
            return await _Context.StudentsDetails.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsDetails>> GetAPI(int id)
        {
            var student = await _Context.StudentsDetails.FindAsync(id);
            if (student == null) return NotFound();
            return student;
        }
        [HttpPost]
        public async Task<ActionResult<StudentsDetails>> CreateAPI(StudentsDetails studentsDetails)
        {
            _Context.StudentsDetails.Add(studentsDetails);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAPI), new { id = studentsDetails.Id }, studentsDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAPI(int id, StudentsDetails studentsDetails)
        {
            if (id != studentsDetails.Id) return BadRequest();
            _Context.Entry(studentsDetails).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAPI(int id)
        {
            var student = await _Context.StudentsDetails.FindAsync(id);
            if (student == null) return NotFound();

            await _Context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('StudentsDetails', RESEED, 0)");
            _Context.StudentsDetails.Remove(student);
            await _Context.SaveChangesAsync();
            return Ok("All students deleted and ID reset to start from 1");
        }
    }
    
}
