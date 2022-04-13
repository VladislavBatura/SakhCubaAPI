namespace SakhCubaAPI.Models.DBModels
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public DateOnly Date { get; set; }
        public string Body { get; set; } = "";
        public string Image { get; set; } = "";
    }
}
