using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class CreateToDoViewModel
    {
        [Required]
        public string? Title { get; set; }
    }
}