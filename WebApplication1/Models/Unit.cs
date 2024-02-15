using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Column("AreaId")]
        public int? AreaId { get; set; }
        public Area? Area { get; set; } = null!;
    }
}
