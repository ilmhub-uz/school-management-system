namespace Student.API.Helpers;

public class FileHelper
{
    private const string Wwwroot = "wwwroot";
    private const string FilesFolder = "StudentAvatarImages";

    private static void CheckDirectory(string folder)
    {
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
    }

    public static async Task<string> SaveStudentAvatarImage(IFormFile file)
    {
        return await SaveFile(file);
    }

    private static async Task<string> SaveFile(IFormFile file)
    {
        CheckDirectory(Path.Combine(Wwwroot,FilesFolder));

        var fileName = Guid.NewGuid() + Path.GetExtension(file.Name);

        var ms = new MemoryStream();

        await file.CopyToAsync(ms);
        await File.WriteAllBytesAsync(Path.Combine(Wwwroot, FilesFolder, fileName), ms.ToArray());

        return $"/{FilesFolder}/{file}";
    }
}