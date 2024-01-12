namespace Onion.Arq.Application.Models
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string? LastName { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual RoleDto? Role { get; set; }
    }
}
