using System;
using System.ComponentModel.DataAnnotations;

namespace Tasker
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Required]
        [Range(1, 5)]
        public int Priority { get; set; }
        public Task()
        {
        }
    }
}
