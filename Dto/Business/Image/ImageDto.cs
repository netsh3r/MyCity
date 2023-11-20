using Business.Model.Location;

namespace Dto.Business.Image;

public class ImageDto : BaseDto
{
    public string Name { get; set; }

    public byte[] Source { get; set; }
}
