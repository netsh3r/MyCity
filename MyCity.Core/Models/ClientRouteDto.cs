namespace MyCity.Core.Models
{
    public class ClientRouteDto: BaseDto
    {
        public long RouteId { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
        public string RoutePoints { get; set; }
        
        public ClientRouteDto()
        {
            this.Id = null;
        }
    }
}
