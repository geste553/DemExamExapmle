using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Models
{
    [Table("Tovar")]
    public class Product
    {
        [Key]
        [Column("id")]
        public byte Id { get; set; }

        [Column("article")]
        public string Article { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("eden")]
        public string Eden { get; set; }

        [Column("price")]
        public short? Price { get; set; }

        [Column("postav")]
        public string Postav { get; set; }

        [Column("proizvod")]
        public string Proizvod { get; set; }

        [Column("cat_tov")]
        public string CatTov { get; set; }

        [Column("sale")]
        public byte? Sale { get; set; }

        [Column("count")]
        public byte? Count { get; set; }

        [Column("info")]
        public string Info { get; set; }

        [Column("photo")]
        public string Photo { get; set; }

        // Псевдонимы для совместимости с кодом и привязками XAML
        [NotMapped]
        public string Unit { get => Eden; set => Eden = value; }

        [NotMapped]
        public string Supplier { get => Postav; set => Postav = value; }

        [NotMapped]
        public string Manufacturer { get => Proizvod; set => Proizvod = value; }

        [NotMapped]
        public string Category { get => CatTov; set => CatTov = value; }

        [NotMapped]
        public int? Discount { get => Sale; set => Sale = (byte?)value; }

        [NotMapped]
        public int? StockQuantity { get => Count; set => Count = (byte?)value; }

        [NotMapped]
        public string Description { get => Info; set => Info = value; }

        [NotMapped]
        public decimal FinalPrice => (Price ?? 0) * (1 - (decimal)(Sale ?? 0) / 100m);

        [NotMapped]
        public string FullPhotoPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Photo))
                    return "pack://application:,,,/Images/picture.png";

                return $"pack://application:,,,/Images/{Photo.Trim()}";
            }
        }
    }
}
