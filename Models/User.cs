﻿namespace TaskManagementAPI.Models
{
    public enum Role { Admin, User }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }

}
