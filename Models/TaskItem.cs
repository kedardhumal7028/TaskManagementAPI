using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.Models
{
    
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int AssignedUserId { get; set; }
       
        public User? AssignedUser { get; set; }

        public List<TaskComment> Comments { get; set; } = new List<TaskComment>();
    }



}
