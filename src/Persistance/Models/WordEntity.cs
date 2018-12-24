using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outloud.QuizService.Persistance.Models
{
    [Table("Words")]
    public class WordEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public WordEntity()
        {

        }

        public WordEntity(string name)
        {
            Name = name;
        }
    }
}
