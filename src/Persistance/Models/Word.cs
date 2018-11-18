using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outloud.QuizService.Persistance.Models
{
    [Table("Words")]
    public class Word
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}
