using System;

namespace Outloud.QuizService.DTO
{
    public class QuizDTO
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

        public QuizDTO(Guid categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    }
}
