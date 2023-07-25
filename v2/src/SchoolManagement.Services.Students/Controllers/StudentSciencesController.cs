﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models.StudentScienceModels;

namespace SchoolManagement.Services.Students.Controllers;

[Route("students/{studentId}/studentsciences")]
[ApiController]
public class StudentSciencesController : ControllerBase
{
    private readonly IStudentScienceManager _studentScienceManager;

    public StudentSciencesController(IStudentScienceManager studentScienceManager)
    {
        _studentScienceManager = studentScienceManager;
    }


    [HttpGet("{scienceId}")]
    public async ValueTask<IActionResult> GetStudentScience(Guid studentId, Guid scienceId)
    {
        var studentScienceModel = await _studentScienceManager.GetStudentScienceAsync(studentId, scienceId);
        if (studentScienceModel == null)
        {
            return NotFound("Object is not found");
        }
        return Ok(studentScienceModel);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetStudentSciences(Guid studentId)
    {
        var studentScienceModels = await _studentScienceManager.GetStudentSciencesByStudentIdAsync(studentId);
        if (studentScienceModels == null)
            return NotFound("Object is not found");

        return Ok(studentScienceModels);
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateStudentScience(Guid studentId, Guid scienceId, UpdateStudentScienceModel updateStudentScience)
    {
        var model = await _studentScienceManager
            .UpdateStudentScienceAsync(studentId, scienceId, updateStudentScience);
        
        return Ok(model);
    }

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteStudentScience(Guid studentId, Guid scienceId)
    {
        var isDelete = await _studentScienceManager.DeleteStudentScienceAsync(studentId, scienceId);
        if (!isDelete)
            return BadRequest("Delete was not completed");

        return Ok();
    }

    [HttpPost]
    public async ValueTask<IActionResult> AddStudentScience(Guid studentId, CreateStudentScienceModel createStudentScience)
    {
        createStudentScience.StudentId = studentId;
        var studentScienceModel = await _studentScienceManager.CreateStudentScienceAsync(createStudentScience);

        return Ok(studentScienceModel);
    }
}
