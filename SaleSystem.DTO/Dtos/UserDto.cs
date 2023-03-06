namespace SaleSystem.DTO.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public string? RoleDescription { get; set; }
        public string? Password { get; set; }
        public int? IsActive { get; set; }
    }
}
