using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outloud.QuizService.Persistance.Models
{
    [Table("Words")]
    public class WordEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid QuizId { get; set; }
        public string Value { get; set; }

        public WordEntity(Guid quizId, string value)
        {
            QuizId = quizId;
            Value = value;
        }
    }
}
