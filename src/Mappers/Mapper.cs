using System;
using Outloud.QuizService.Dto;
using Outloud.QuizService.Persistance.Models;

namespace Outloud.QuizService.Mappers
{
    public static class Mapper
    {
        public static CategoryEntity Map(CategoryDTO entity) => new CategoryEntity(entity.Name);
    }
}
