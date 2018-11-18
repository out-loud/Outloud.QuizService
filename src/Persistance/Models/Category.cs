using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outloud.QuizService.Persistance.Models
{
    [Table("Categories")]
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Quiz> Quizes { get; set; }

        public Category()
        {
            Id = Guid.NewGuid();
        }
    }
}
