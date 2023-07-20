namespace Student.API.Exceptions;

public class UpdateStudentAttendanceValidationInValid : Exception
{
    public UpdateStudentAttendanceValidationInValid(string message) : base($"Update StudentAttendanceValidation InValid!: {message}") { }
}
