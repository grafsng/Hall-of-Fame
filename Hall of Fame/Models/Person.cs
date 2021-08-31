using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hall_of_Fame.Models
{
    public class Person
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Введите ФИО")]
        [MaxLength(100, ErrorMessage = "ФИО не должно превышать 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите имя, видимое в системе")]
        [MaxLength(40, ErrorMessage = "Отображаемое имя не должно превышать 40 символов")]
        public string DisplayName { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
