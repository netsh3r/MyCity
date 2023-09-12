namespace MyCity.Core.Models
{
    /// <summary>
    /// DTO мероприятия
    /// </summary>
    public class EventDto : BaseDto
    {
        /// <summary>
        /// Название мероприятия
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание мероприятия
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Дата и время начала мероприятия
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Дата и время окончания мероприятия
        /// </summary>
        public DateTime DateEnd { get; set; }
        /// <summary>
        /// Id места проведения мероприятия
        /// </summary>
        public long LocationId { get; set; }
        /// <summary>
        /// Список ссылок/id картинок
        /// </summary>
        public List<string> Images { get; set; }
    }
}
