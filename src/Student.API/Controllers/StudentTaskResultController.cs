using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.API.Managers;
using Student.API.Managers.Interfaces;

namespace Student.API.Controllers
{
    [Route("api/students/{username}/task-results")]
    [ApiController]
    public class StudentTaskResultController : ControllerBase
    {
        private readonly IStudentTaskResultManager _studentTaskResultManager;
        private readonly IStudentManager _studentManager;
        public StudentTaskResultController(
            IStudentTaskResultManager studentTaskResultManager, 
            IStudentManager studentManager)
        {
            _studentTaskResultManager = studentTaskResultManager;
            _studentManager = studentManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentTaskResults()
        {
            var studentTaskResults = await _studentTaskResultManager.GetStudentTaskResultsAsync();
            return Ok(studentTaskResults);
        }
        [HttpPost("{taskId}")]
        public async Task<IActionResult> AddStudentTaskResult(string username,Guid taskId,string content)
        {
            var student = await _studentManager.GetStudentByUserNameAsync(username);
            var studentTaskResult = await _studentTaskResultManager.AddStudentTaskResultAsync(student.Id, taskId, content);
            return Ok(studentTaskResult);
        }

        [HttpPut("{taskId]")]
        public async Task<IActionResult> UpdateStudentTaskResult(string username, Guid taskId, string content)
        {
            var student = await _studentManager.GetStudentByUserNameAsync(username);
             await _studentTaskResultManager.UpdateStudentTaskResultAsync(student.Id, taskId, content);
            return Ok();
        }
        [HttpPut("{taskId]")]
        public async Task<IActionResult> UpdateStudentTaskResult(string username, Guid taskId)
        {
            var student = await _studentManager.GetStudentByUserNameAsync(username);
            await _studentTaskResultManager.DeleteStudentTaskResultAsync(student.Id, taskId);
            return Ok();
        }


    }
}
