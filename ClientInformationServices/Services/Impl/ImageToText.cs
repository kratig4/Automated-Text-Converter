using IronOcr;

namespace ClientInformationServices.Services.Impl
{
    public class ImageToText : IImageToText
    {
        public string call(string filePath)
        {
            var ocr = new IronTesseract();

            using (var ocrInput = new OcrInput())
            {
                ocrInput.AddImage(filePath);

                var ocrResult = ocr.Read(ocrInput);
                return ocrResult.Text;
            }
        }
    }
}
