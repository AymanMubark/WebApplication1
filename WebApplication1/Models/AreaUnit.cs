using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class AreaUnit
    {
        public int Id { get; set; }
        [Column("UnitId")]
        public int? UnitId { get; set; }
        public Unit? Unit { get; set; } = null!;

        [Column("AreaId")]
        public int? AreaId { get; set; }
        public Area? Area { get; set; } = null!;
    }
}
