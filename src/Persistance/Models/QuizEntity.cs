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
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<WordEntity> Words { get; set; }

        public QuizEntity(Guid categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    }
}
