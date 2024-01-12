namespace Onion.Arq.Application.Models
{
    public class BaseDto
    {
        public int Id { get; set; }
        public bool? Activated { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
