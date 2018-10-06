using System.Collections.Generic;
using Google.Cloud.Speech.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Outloud.QuizService.Models;

namespace Outloud.QuizService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SpeechController : Controller
    {
        [HttpPost]
        public ActionResult Post([FromForm] SpeechData speechData)
        {
            if (speechData?.Speech == null || speechData.Speech.Length == 0)
                return NoContent();

            var results = new List<string>();
            var speech = SpeechClient.Create();
            using (var stream = speechData.Speech.OpenReadStream())
            {
                var response = speech.Recognize(new RecognitionConfig
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.AmrWb,
                    SampleRateHertz = 16000,
                    LanguageCode = "en",
                }, RecognitionAudio.FromStream(stream));
                
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        results.Add(alternative.Transcript);
                    }
                }
            }
            return Accepted(results);
        }
    }
}