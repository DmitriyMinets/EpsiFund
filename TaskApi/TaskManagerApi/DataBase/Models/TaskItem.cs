﻿using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
