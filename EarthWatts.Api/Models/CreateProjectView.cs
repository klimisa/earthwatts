using System.ComponentModel.DataAnnotations;

namespace EarthWatts.Api.Models
{
    public class CreateProjectView
    {
        [Required(ErrorMessage = "The created by is required")]
        public int CreatedBy { get; set; }

        [Required(ErrorMessage = "The project title is required")]
        public string ProjectTitle { get; set; }

        [Required(ErrorMessage = "The project description is required")]
        public string ProjectDescription { get; set; }
    }
}