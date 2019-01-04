using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outloud.QuizService.Persistance.Models
{
    [Table("Quizes")]
    public class QuizEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<WordEntity> Words { get; set; }

        public QuizEntity()
        {

        }

        public QuizEntity(string name)
        {
            Name = name;
        }
    }
}
