namespace Dal.Entities
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }

        public byte[] Source { get; set; }
    }
}
