using System;

namespace Outloud.QuizService.DTO
{
    public class QuizDTO
    {
        public Guid ParentId { get; set; }
        public string Name { get; set; }

        public QuizDTO(string name)
        {
            Name = name;
        }
    }
}
