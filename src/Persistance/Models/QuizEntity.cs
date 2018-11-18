using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outloud.QuizService.Persistance.Models
{
    [Table("Quizes")]
    public class QuizEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<WordEntity> Words { get; set; }

        public QuizEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
