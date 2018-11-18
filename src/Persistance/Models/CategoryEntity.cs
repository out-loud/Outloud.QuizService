using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outloud.QuizService.Persistance.Models
{
    [Table("Categories")]
    public class CategoryEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<QuizEntity> Quizes { get; set; }

        public CategoryEntity()
        {
            Id = Guid.NewGuid();
        }
        public CategoryEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
