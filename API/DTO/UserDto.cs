using API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API.Helpers;

namespace API.DTO
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public static implicit operator User(UserDto dto)
            => new User().CopyProperties(dto);
        public static implicit operator UserDto(User ing)
            => new UserDto().CopyProperties(ing);
    }
}
