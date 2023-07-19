namespace Student.API.Exceptions;

public class StudentAttendanceNotFoundException:Exception
{
    public StudentAttendanceNotFoundException(string message) : base(message) { }
}