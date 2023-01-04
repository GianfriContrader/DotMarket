namespace DotMarket.DTO
{
    public class RoleDTO
    {
    }

    public class RoleEditDTO
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; } = new List<User>();

        public IEnumerable<User> NonMembers { get; set; } = new List<User>();
    }

    public class RoleModificationDTO
    {
        public string RoleName { get; set; } = string.Empty;

        public string RoleId { get; set; } = string.Empty;

        public string[]? AddIds { get; set; }

        public string[]? DeleteIds { get; set; }
    }
}
