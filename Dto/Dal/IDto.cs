namespace Dto.Dal;

public interface IDto<TPrimaryKey>
{
    TPrimaryKey? Id { get; set; }
}

public interface IDto : IDto<long?>
{
}