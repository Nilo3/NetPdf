using iText.Kernel.Pdf;
using Xunit;

public class PdfTextExtractorServiceTestsV2
{
    private readonly PdfTextExtractorService _pdfTextExtractorService;

    public PdfTextExtractorServiceTestsV2()
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
        {
            using (var writer = new PdfWriter(ms))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var page = pdf.AddNewPage();
                    var canvas = new iText.Kernel.Pdf.Canvas.PdfCanvas(page);
                    var document = new iText.Layout.Document(pdf);
                    document.Add(new iText.Layout.Element.Paragraph("Este es un texto de prueba."));
                }
            }
            return ms.ToArray();
        }
    }
}

internal class FactAttribute : Attribute
{
}