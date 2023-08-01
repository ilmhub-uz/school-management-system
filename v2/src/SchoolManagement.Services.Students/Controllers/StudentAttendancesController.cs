using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Students.Managers;
using SchoolManagement.Services.Students.Models.StudentAttendanceModels;

namespace SchoolManagement.Services.Students.Controllers
{
    [Route("api/students/{studentId}/atendances")]
    [ApiController]
    public class StudentAttendancesController : ControllerBase
    {
        private readonly IStudentAttendanceManager _manager;
        public StudentAttendancesController(IStudentAttendanceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentAttendances(Guid studentId) 
        {
            try
            {
              var studentAttendance = await _manager.GetStudentAttendances(studentId);
                return Ok(studentAttendance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddStudentAttendance(Guid studentId, [FromBody] CreateStudentAttendanceModel model)
        {
            try
            {
             var studentAttendance =   await _manager.AddStudentAtttendance(studentId, model);
                return Ok(studentAttendance);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{topicId}")]
        public async Task<IActionResult> UpdateStudentAttendance(Guid studentId,Guid topicId, [FromBody] UpdateStudentAttendanceModel model)
        {
            try
            {
               await _manager.UpdateStudentAttendance(studentId, topicId, model);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
