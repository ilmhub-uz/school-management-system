namespace Student.API.Exceptions;

public class StudentNotFoundException : Exception
{
    public StudentNotFoundException() : base("User not found!") { }

}