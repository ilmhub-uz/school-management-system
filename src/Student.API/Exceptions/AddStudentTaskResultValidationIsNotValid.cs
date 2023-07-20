namespace Student.API.Exceptions;

public class AddStudentTaskResultValidationIsNotValid : Exception
{
    public AddStudentTaskResultValidationIsNotValid(string message) : base(message) { }
}
