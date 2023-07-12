using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInformationServices.Services
{
    public interface IAudioToTextService
    {
        string call(string filePath);
    }
}
