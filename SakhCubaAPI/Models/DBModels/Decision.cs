using System.ComponentModel.DataAnnotations;

namespace SakhCubaAPI.Models.DBModels
{
    public class Decision
    {
        public int Id { get; set; }
        [Display(Name = "Решение")]
        public string DecisionName { get; set; } = "";
        public List<Application> Applications { get; set; } = new List<Application>();
    }
}
