using Microsoft.AspNetCore.Mvc;
using StudentAttendanceManagement.Model;
using StudentAttendanceManagement.Models.Students;
using StudentAttendanceManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAttendanceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        private IStudentsService _studentService;

        public StudentAttendanceController(IStudentsService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _studentService.GetAll();
            return Ok(users);
        }

        
        [HttpGet]
        [Route("GetbyID/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _studentService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Create(CreateRequestStudent model)
        {
            await _studentService.Create(model);
            return Ok(new { message = "Student created" });
        }

        
        [HttpPost]
        [Route("UpdatebyID/{id}")]
        public async Task<IActionResult> Update(int id, UpdateRequestStudent model)
        {
            await _studentService.Update(id, model);
            return Ok(new { message = "User updated" });
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.Delete(id);
            return Ok(new { message = "Student deleted" });
        }
    }
}
