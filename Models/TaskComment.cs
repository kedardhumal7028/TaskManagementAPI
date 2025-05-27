namespace TaskManagementAPI.Models
{
    public class TaskComment
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;

        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }

}
