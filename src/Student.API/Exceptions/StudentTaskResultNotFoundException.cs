namespace Student.API.Exceptions;

public class StudentTaskResultNotFoundException:Exception
{
    public StudentTaskResultNotFoundException() : base("Student or Student's result not found!") { }
}