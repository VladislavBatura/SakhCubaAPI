using System.ComponentModel.DataAnnotations;

namespace SakhCubaAPI.Models.DBModels
{
    public class Application
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = "";
        public string DiscordNickname { get; set; } = "";
        public string About { get; set; } = "";
        public string Ip { get; set; } = "";
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int DecisionId { get; set; }
        public Decision Decision { get; set; } = new Decision();
    }
}
