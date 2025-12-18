namespace EnterpriseApi.Domain.Entities
{
    public class User
    {
        // =========================
        // Primary Key
        // =========================
        public Guid Id { get; set; }

        // =========================
        // Basic Info
        // =========================
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        // =========================
        // Security
        // =========================
        public string PasswordHash { get; set; } = null!;

        public string Role { get; set; } = "User";

        // =========================
        // Status & Audit
        // =========================
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
