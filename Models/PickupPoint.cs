using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Models
{
    [Table("pvz")]
    public class PickupPoint
    {
        [Key]
        [Column("id")]
        public byte Id { get; set; }

        [Column("number")]
        public int? Number { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("street")]
        public string Street { get; set; }

        [Column("home")]
        public byte? Home { get; set; }

        [NotMapped]
        public string Address => $"{City}, {Street}, д. {Home}".Trim(',', ' ');
    }
}
