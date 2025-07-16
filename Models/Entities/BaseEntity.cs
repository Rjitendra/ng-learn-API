namespace Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid PkId { get; set; } = Guid.NewGuid();
        public string JsonDoc { get; set; } = string.Empty;
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool IsValid { get; set; } = true;
        public bool IsVisible { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public int? BaseVersionId { get; set; }
        public int? VersionId { get; set; }
        public bool IsLatestVersion { get; set; } = true;
        public int? StatusId { get; set; }
    }
}
