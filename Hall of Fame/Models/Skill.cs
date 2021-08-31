using System.ComponentModel.DataAnnotations;

namespace Hall_of_Fame.Models
{
    public class Skill
    {
        [Required(ErrorMessage = "Укажите название навыка")]
        [MaxLength(20, ErrorMessage = "Название навыка не должно превышать 20 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите уровень навыка")]
        [Range(1, 10, ErrorMessage = "Уровень навыка может быть в диапазоне от 1 до 10")]
        public byte Level { get; set; } //1-10
       
    }
}
