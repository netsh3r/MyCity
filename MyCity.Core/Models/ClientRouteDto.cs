namespace MyCity.Core.Models
{
    public class ClientRouteDto
    {
        public long RouteId { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
        public ClientRoutePointsDto[] RoutePoints { get; set; }
    }
}
