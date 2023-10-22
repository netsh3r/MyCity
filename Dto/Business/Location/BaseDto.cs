namespace Business.Model.Location;

public class BaseDto<TPrimaryKey>
{
    public TPrimaryKey? Id { get; set; }
}

public class BaseDto : BaseDto<long?>
{
}