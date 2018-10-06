using Microsoft.AspNetCore.Http;

namespace Outloud.QuizService.Models
{
    public class SpeechData
    {
        public IFormFile Speech { get; set; }
    }
}
