public class FileValidationService
{
    private readonly string[] validExtensions = { ".pdf" };

    public (bool IsValid, string ErrorMessage) ValidateFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return (false, "No file uploaded.");
        }

        var fileExtension = Path.GetExtension(file.FileName).ToLower();
        if (!validExtensions.Contains(fileExtension))
        {
            return (false, $"El formato {fileExtension} del archivo no es valido, el unico formato valido es pdf.");
        }

        if (file.ContentType != "application/pdf")
        {
            return (false, $"El formato {file.ContentType} del archivo no es valido, el unico formato valido es pdf.");
        }

        return (true, string.Empty);
    }
}
