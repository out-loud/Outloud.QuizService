using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outloud.QuizService.Persistance.Models
{
    [Table("Quizes")]
    public class Quiz
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Word> Words { get; set; }

        public Quiz()
        {
            Id = Guid.NewGuid();
        }
    }
}
