using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Dto
{
    public abstract class VersionedDtoBase
    {
        public int? Id { get; set; }
        public Guid? PkId { get; set; }
        public bool IsValid { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsLatestVersion { get; set; }
        public int? BaseVersionId { get; set; }
        public int? VersionId { get; set; }
        public int? StatusId { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        // 🚨 Only used for input
       // [JsonIgnore] // 👈 this line hides it from serialization
        public OperationType? OperationType { get; set; }
    }
}
