using System;

namespace Outloud.QuizService.DTO
{
    public class WordDTO
    {
        public Guid QuizId{ get; set; }
        public string Value { get; set; }

        public WordDTO(string value)
        {
            Value = value;
        }
    }
}
