using System;

namespace Outloud.QuizService.DTO
{
    public class WordDTO
    {
        public Guid ParentId{ get; set; }
        public string Name { get; set; }

        public WordDTO(string name)
        {
            this.Name = name;
        }
    }
}
