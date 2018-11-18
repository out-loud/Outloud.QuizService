using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outloud.QuizService.Persistance.Models
{
    [Table("Words")]
    public class WordEntity
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}
