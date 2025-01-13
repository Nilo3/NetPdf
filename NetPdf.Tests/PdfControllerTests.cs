using iText.Kernel.Pdf;
using Xunit;

public class PdfTextExtractorServiceTests
{
    private readonly PdfTextExtractorService _pdfTextExtractorService;

    public PdfTextExtractorServiceTests()
    {
        _pdfTextExtractorService = new PdfTextExtractorService();
    }

    [Fact]
    public void ExtractTextFromPdf_ShouldReturnCorrectText_WhenValidPdfIsProvided()
    {
        // Arrange: Crear un archivo PDF en memoria con texto simple
        var pdfBytes = CreatePdfWithSimpleText();

        // Act: Llamar al servicio para extraer el texto
        var extractedText = _pdfTextExtractorService.ExtractTextFromPdf(pdfBytes);

        // Assert: Verificar que el texto extraído sea correcto
        Assert.Contains("Este es un texto de prueba", extractedText);
    }

    private byte[] CreatePdfWithSimpleText()
    {
        using (var ms = new MemoryStream())
        using (var writer = new PdfWriter(ms))
        using (var pdf = new PdfDocument(writer))
        using (var document = new iText.Layout.Document(pdf))
        {
            document.Add(new iText.Layout.Element.Paragraph("Este es un texto de prueba."));
            document.Close(); // Cerrar explícitamente el documento

            return ms.ToArray();
        }
    }
}

public class PdfTextExtractorServiceTestsV3
{
    [Fact]
    public void ExtractTextFromPdf_ShouldReturnExtractedText_WhenValidPdfProvided()
    {
        // Arrange
        var service = new PdfTextExtractorService();
        string expectedText = "Hello, world!";
        byte[] pdfBytes = CreatePdfWithText(expectedText);

        // Act
        string extractedText = service.ExtractTextFromPdf(pdfBytes);

        // Assert
        Assert.Equal(expectedText, extractedText);
    }

    private byte[] CreatePdfWithText(string text)
    {
        using (var memoryStream = new MemoryStream())
        using (var writer = new iText.Kernel.Pdf.PdfWriter(memoryStream))
        using (var pdfDoc = new iText.Kernel.Pdf.PdfDocument(writer))
        using (var document = new iText.Layout.Document(pdfDoc))
        {
            document.Add(new iText.Layout.Element.Paragraph(text));
            document.Close(); // Cerrar explícitamente el documento

            return memoryStream.ToArray();
        }
    }
}