namespace SchoolManagement.Services.Identity.Models;

public record TokenResultModel(string Token, double Expires, DateTime Date);