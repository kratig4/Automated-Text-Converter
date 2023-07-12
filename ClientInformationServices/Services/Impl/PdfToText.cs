using IronOcr;


namespace ClientInformationServices.Services.Impl
{
    public class PdfToText : IPdfToText
    {
        public  string ExtractTextFromPdf(string filePath)
        {
            var ocr = new IronTesseract();

            using (var ocrInput = new OcrInput())
            {
                ocrInput.AddPdf(filePath);

                var ocrResult = ocr.Read(ocrInput);
                return ocrResult.Text;
            }
        }
    }
}
