namespace Student.API.Exceptions;

public class UpdateStudentScienceValidationIsNotValidException : Exception
{
    public UpdateStudentScienceValidationIsNotValidException(string message) : base(message) { }
}