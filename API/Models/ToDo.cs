using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool Done { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}