using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Text;

public class PdfTextExtractorService
{
    public string ExtractTextFromPdf(byte[] pdfBytes)
    {
        StringBuilder text = new StringBuilder();

        using (var memoryStream = new MemoryStream(pdfBytes))
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(memoryStream));
            for (int pageNumber = 1; pageNumber <= pdfDoc.GetNumberOfPages(); pageNumber++)
            {
                var strategy = new SimpleTextExtractionStrategy();
                var page = pdfDoc.GetPage(pageNumber);
                string pageText = PdfTextExtractor.GetTextFromPage(page, strategy);
                text.Append(pageText);
            }
        }

        return text.ToString();
    }
}