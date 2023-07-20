using Microsoft.AspNetCore.Http;
using SchoolManagement.Common.Interfaces;

namespace SchoolManagement.Common.Services;

public class FileManager : IFileManager
{
    private readonly string _rootFolder = "wwwroot";

    private string CheckFolder(string folderName)
    {
        var rootPath = Path.Combine(Environment.CurrentDirectory, _rootFolder);

        if (!Directory.Exists(rootPath))
            Directory.CreateDirectory(rootPath);

        var folderPath = Path.Combine(rootPath, folderName);

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        return folderPath;
    }

    public async Task<string> SaveFileAsync(IFormFile iFormFile, string folderName)
    {
        var folderPath = CheckFolder(folderName);

        var newFileName = Guid.NewGuid() + Path.GetExtension(iFormFile.FileName);

        var filePath = Path.Combine(folderPath, newFileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await iFormFile.CopyToAsync(stream);

        return filePath;
    }

    public void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }
}