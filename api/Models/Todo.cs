namespace api.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }

        public Boolean isCompleted { get; set; } = false;

        public string UserId { get; set; }
    public AppUser User { get; set; }
    }
}