using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public byte Id { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Column("surename")]
        public string Surename { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("stepname")]
        public string Stepname { get; set; }

        [Column("Логин")]
        public string Login { get; set; }

        [Column("Пароль")]
        public string Password { get; set; }

        [NotMapped]
        public string Логин
        {
            get => Login;
            set => Login = value;
        }

        [NotMapped]
        public string Пароль
        {
            get => Password;
            set => Password = value;
        }

        [NotMapped]
        public string FullName => $"{Surename} {Name} {Stepname}".Trim();
    }
}
