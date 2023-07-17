using FluentValidation;

namespace Student.API.Exceptions;

public class UpdateStudentAttendanceValidationInValid:Exception
{
    public UpdateStudentAttendanceValidationInValid(string message) : base(message){ }
}
