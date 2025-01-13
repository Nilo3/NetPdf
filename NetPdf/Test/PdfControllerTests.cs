using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class PdfControllerTests
{
    private readonly Mock<PdfTextExtractorService> _mockPdfTextExtractorService;
    private readonly Mock<FileValidation> _mockFileValidationService;
    private readonly PdfController _controller;

    public PdfControllerTests()
    {
        _mockPdfTextExtractorService = new Mock<PdfTextExtractorService>();
        _mockFileValidationService = new Mock<FileValidation>();
        _controller = new PdfController(_mockPdfTextExtractorService.Object, _mockFileValidationService.Object);
    }

    [Fact]
    public async Task ExtractTextFromPdf_ShouldReturnText_WhenValidPdfIsProvided()
    {
        // Arrange
        var mockPdfFile = new Mock<IFormFile>();
        var pdfBytes = new byte[] { 1, 2, 3, 4 }; // Suponiendo que esto es un archivo PDF válido.

        _mockFileValidationService.Setup(f => f.ValidateFile(mockPdfFile.Object)).Returns((true, string.Empty));
        _mockPdfTextExtractorService.Setup(s => s.ExtractTextFromPdf(It.IsAny<byte[]>())).Returns("Texto extraído correctamente.");

        // Act
        var result = await _controller.ExtractTextFromPdf(mockPdfFile.Object);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = okResult.Value as dynamic;
        Assert.Equal("Texto extraído correctamente.", response?.text);
    }

    [Fact]
    public async Task ExtractTextFromPdf_ShouldReturnBadRequest_WhenInvalidFileIsProvided()
    {
        // Arrange
        var mockPdfFile = new Mock<IFormFile>();
        _mockFileValidationService.Setup(f => f.ValidateFile(mockPdfFile.Object)).Returns((false, "Archivo no válido"));

        // Act
        var result = await _controller.ExtractTextFromPdf(mockPdfFile.Object);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Archivo no válido", badRequestResult.Value);
    }
}