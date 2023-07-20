namespace Student.API.Exceptions;

public class UpdateStudentAttendanceValidationInValidException : Exception
{
    public UpdateStudentAttendanceValidationInValidException(string message) : base($"Update StudentAttendanceValidation InValid!: {message}") { }
}
