namespace StudentAdmissionManagement.Controllers;

using Microsoft.AspNetCore.Mvc;
using StudentAdmissionManagement.Models.Students;
using StudentAdmissionManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

[ApiController]
[Route("[controller]")]
public class StudentAdmissionController : ControllerBase
{
    private IStudentsService _studentService;

    public StudentAdmissionController(IStudentsService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _studentService.GetAll();
        return Ok(users);
    }

    //[HttpGet("{id}")]
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

    //[HttpPost("{id}")]
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

