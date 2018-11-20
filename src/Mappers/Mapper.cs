using Outloud.QuizService.Dto;
using Outloud.QuizService.DTO;
using Outloud.QuizService.Persistance.Models;

namespace Outloud.QuizService.Mappers
{
    public static class Mapper
    {
        public static CategoryEntity Map(CategoryDTO entity) => new CategoryEntity(entity.Name);
        public static CategoryDTO Map(CategoryEntity entity) => new CategoryDTO(entity.Name);

        public static QuizEntity Map(QuizDTO entity) => new QuizEntity(entity.ParentId, entity.Name);
        public static QuizDTO Map(QuizEntity entity) => new QuizDTO(entity.ParentId, entity.Name);

        public static WordEntity Map(WordDTO entity) => new WordEntity(entity.ParentId, entity.Name);
        public static WordDTO Map(WordEntity entity) => new WordDTO(entity.Name);
    }
}
