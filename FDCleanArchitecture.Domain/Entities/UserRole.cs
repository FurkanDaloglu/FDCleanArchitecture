using FDCleanArchitecture.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace FDCleanArchitecture.Domain.Entities
{
    public sealed class UserRole:Entity
    {
        [ForeignKey("User")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [ForeignKey("User")]
        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}
