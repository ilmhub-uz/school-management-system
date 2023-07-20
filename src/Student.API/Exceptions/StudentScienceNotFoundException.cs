namespace Student.API.Exceptions;

public class StudentScienceNotFoundException : Exception
{
    public StudentScienceNotFoundException() : base("StudentScience not found!") { }
}