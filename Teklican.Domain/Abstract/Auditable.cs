using System.ComponentModel.DataAnnotations;

namespace Teklican.Domain.Abstract
{
    public abstract class Auditable 
    {
        public DateTime CreatedDate { get ; set ; }
        [MaxLength(256)]
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdateDate { get; set; }
        [MaxLength(256)]
        public string? UpdateBy { get ; set; }
    }
}
