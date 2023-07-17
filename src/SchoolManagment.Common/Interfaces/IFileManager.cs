using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Common.Interfaces;

public interface IFileManager
{
    Task<string> SaveFileAsync(IFormFile iFormFile, string folderName);
    void DeleteFile(string filePath);
}