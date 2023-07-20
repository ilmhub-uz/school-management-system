namespace Student.API.Exceptions;

public class AddStudentTaskResultValidationIsNotValidException : Exception
{
    public AddStudentTaskResultValidationIsNotValidException(string message) : base(message) { }
}
