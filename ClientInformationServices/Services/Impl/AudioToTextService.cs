using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Speech.V1;
using Grpc.Auth;

namespace ClientInformationServices.Services.Impl
{
    public class AudioToTextService : IAudioToTextService
    {
        public string call(string filePath)
        {
            if (filePath != "")
            {
                string processfile = filePath;

                GoogleCredential googleCredential;
                StringBuilder sb1 = new StringBuilder();
                using (Stream m = new FileStream(@"sidproject-2102-2360d6244d15.json", FileMode.Open))
                    googleCredential = GoogleCredential.FromStream(m);
                var client = new SpeechClientBuilder { ChannelCredentials = googleCredential.ToChannelCredentials() }.Build();

                var response = client.Recognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    //SampleRateHertz = 16000,
                    LanguageCode = "hu",
                }, RecognitionAudio.FromFile(processfile));
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        sb1.Append((alternative.Transcript));
                    }
                }

                 return sb1.ToString();
            }
            return "";
        }
    }
}
