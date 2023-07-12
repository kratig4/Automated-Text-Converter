using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInformationServices.Services
{
    public interface IPdfToText
    {
        string ExtractTextFromPdf(string filePath);
    }
}
