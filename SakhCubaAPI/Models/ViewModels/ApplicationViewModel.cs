using System.ComponentModel.DataAnnotations;

namespace SakhCubaAPI.Models.ViewModels
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = "";
        public string DiscordNickname { get; set; } = "";
        public string About { get; set; } = "";
        public string Ip { get; set; } = "";
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int DecisionId { get; set; }
        public string Decision { get; set; } = "";
    }
}
