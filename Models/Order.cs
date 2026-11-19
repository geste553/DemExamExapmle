using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        public byte Id { get; set; }

        [Column("article")]
        public string Article { get; set; }

        [Column("date_order")]
        public DateTime? DateOrder { get; set; }

        [Column("date_post")]
        public DateTime? DatePost { get; set; }

        [Column("adress")]
        public byte? Adress { get; set; }

        [Column("surename")]
        public string Surename { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("stepname")]
        public string Stepname { get; set; }

        [Column("code")]
        public short? Code { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("id_t")]
        public byte? IdT { get; set; }

        [Column("id_u")]
        public byte? IdU { get; set; }

        [NotMapped]
        public int OrderNumber { get => Id; set => Id = (byte)value; }

        [NotMapped]
        public string Articles { get => Article; set => Article = value; }

        [NotMapped]
        public DateTime? OrderDate { get => DateOrder; set => DateOrder = value; }

        [NotMapped]
        public DateTime? DeliveryDate { get => DatePost; set => DatePost = value; }

        [NotMapped]
        public int? PickupPointId { get => Adress; set => Adress = (byte?)value; }

        [NotMapped]
        public int? PickupCode { get => Code; set => Code = (short?)value; }

        [NotMapped]
        public string ClientFullName => $"{Surename} {Name} {Stepname}".Trim();
    }
}
