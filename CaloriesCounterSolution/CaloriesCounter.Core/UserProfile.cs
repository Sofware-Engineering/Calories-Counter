using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CaloriesCounter.Core.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Вкажіть вік")]
        [Range(18, 100, ErrorMessage = "Вік повинен бути від 18 до 100 років")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Вкажіть стать")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Вкажіть вагу")]
        [Range(30, 300, ErrorMessage = "Вага повинна бути від 30 до 300 кг")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Вкажіть зріст")]
        [Range(100, 250, ErrorMessage = "Зріст повинен бути від 100 до 250 см")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Вкажіть рівень активності")]
        public ActivityLevel ActivityLevel { get; set; }

        [Required(ErrorMessage = "Вкажіть мету")]
        public Goal Goal { get; set; }
    }
}
