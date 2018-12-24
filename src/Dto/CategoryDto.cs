namespace Outloud.QuizService.Dto
{
    public class CategoryDTO
    {
        public string Name { get; set; }

        public CategoryDTO(string name)
        {
            Name = name;
        }
    }
}