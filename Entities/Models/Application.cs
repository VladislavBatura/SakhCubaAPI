using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Application
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Ник не может быть длиннее 100 символов")]
        public string Nickname { get; set; } = "";

        [StringLength(50, ErrorMessage = "Дискорд не может быть длиннее 50 символов")]
        public string DiscordNickname { get; set; } = "";

        [StringLength(2000, ErrorMessage = "Не больше 2000 символов в графе О себе")]
        public string About { get; set; } = "";
        public string Ip { get; set; } = "";
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Decision))]
        public int DecisionId { get; set; }
        public Decision Decision { get; set; }
    }
}
