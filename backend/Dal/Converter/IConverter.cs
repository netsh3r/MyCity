using Dal.Entities;
using Dto.Dal;

namespace Dal.Converter;

public interface IConverter<TModel, TPrimaryKey, TEntity>
    where TModel : IDto
    where TEntity : IEntity<TPrimaryKey>
{
    TModel? Convert(TEntity? entity);
    TEntity Convert(TModel model);
}