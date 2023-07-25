using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Core.HelperServices;

public class FileManager
{
    private readonly string _rootFolderName = "wwwroot";

    private string CheckDirectory(string folderName)
    {
        var rootDirectory = Path.Combine(Environment.CurrentDirectory, _rootFolderName);
        if (!Directory.Exists(rootDirectory))
            Directory.CreateDirectory(rootDirectory);

        var folderDirectory = Path.Combine(rootDirectory, folderName);

        if (!Directory.Exists(folderDirectory))
            Directory.CreateDirectory(folderDirectory);

        return folderDirectory;
    }

    public async Task<string> SaveFileAsync(string folderName, IFormFile iFormFile)
    {
        var folderPath = CheckDirectory(folderName);

        var fileName = Guid.NewGuid() + Path.GetExtension(iFormFile.Name);

        var filePath = Path.Combine(folderPath, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await iFormFile.CopyToAsync(stream);

        return filePath;
    }

    public void DeleteFile(string filePath)
    {
        if(File.Exists(filePath))
            File.Delete(filePath);
    }
}