using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Decision
    {
        public int Id { get; set; }
        [Display(Name = "Решение")]
        public string DecisionName { get; set; } = "";
        public List<Application> Applications { get; set; } = new List<Application>();
    }
}
