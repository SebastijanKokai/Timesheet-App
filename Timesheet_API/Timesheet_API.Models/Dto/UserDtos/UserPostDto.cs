namespace Timesheet_API.Models.Dto.UserDtos
{
    public class UserPostDto
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public int HoursPerWeek { get; set; }
        public string? Email { get; set; } 
        public string? UserStatus { get; set; }
        public string? RoleName { get; set; }
    }
}
