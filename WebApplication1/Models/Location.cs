using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Column("UnitId")]
        public int? UnitId { get; set; }
        public Unit? Unit { get; set; } = null!;
    }
}
