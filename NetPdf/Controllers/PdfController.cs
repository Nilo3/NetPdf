using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PdfController : ControllerBase
{
    private readonly PdfTextExtractorService _pdfTextExtractorService;
    private readonly FileValidation _fileValidationService;

    public PdfController(PdfTextExtractorService pdfTextExtractorService, FileValidation fileValidationService)
    {
        _pdfTextExtractorService = pdfTextExtractorService;
        _fileValidationService = fileValidationService;
    }

    [HttpPost("extract-text")]
    public async Task<IActionResult> ExtractTextFromPdf(IFormFile pdfFile)
    {
        // Validar el archivo usando el servicio de validación
        var (isValid, errorMessage) = _fileValidationService.ValidateFile(pdfFile);

        if (!isValid)
        {
            return BadRequest(errorMessage);
        }

        using (var memoryStream = new MemoryStream())
        {
            await pdfFile.CopyToAsync(memoryStream);
            byte[] pdfBytes = memoryStream.ToArray();

            string extractedText = _pdfTextExtractorService.ExtractTextFromPdf(pdfBytes);

            return Ok(new { text = extractedText });
        }
    }
}