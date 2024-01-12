namespace Onion.Arq.Application.Models
{
    public class SessionDto : BaseDto
    {
        public int UserId { get; set; }
        public bool? Active { get; set; }
        public string? Token { get; set; }
        public UserDto User { get; set; }
    }
}
