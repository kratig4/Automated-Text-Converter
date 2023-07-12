using ClientInformationServices.Services;
using ClientInformationServices.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ClientInformationTool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientInformationController : ControllerBase
    {

        private readonly IAudioToTextService _audioToTextService;
        private readonly IPdfToText _pdfToText;
        private readonly IImageToText _imageToText;

        public ClientInformationController(IAudioToTextService audioToTextService, IPdfToText pdfToText, IImageToText imageToText)
        {
            _audioToTextService = audioToTextService;
            _pdfToText = pdfToText;
            _imageToText = imageToText;
        }

        [HttpGet("clientinfo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetClientInformation([FromQuery] string filePath)
        {
            var txt = "";
            try
            {
              
                string path = Path.GetExtension(filePath);
                if (path.Contains(".pdf")){
                    txt = _pdfToText.ExtractTextFromPdf(filePath);
                }
                if (path.Contains(".png"))
                {
                    txt = _imageToText.call(filePath);
                }
                if (path.Contains(".wav"))
                {
                    txt = _audioToTextService.call(filePath);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(txt);
        }
    }
}