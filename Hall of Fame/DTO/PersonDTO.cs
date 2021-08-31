using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hall_of_Fame.Models;

namespace Hall_of_Fame.DTO
{
    public class PersonDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public List<Skill> Skills { get; set; }
        public List<Person> Workers { get; set; }
    }
}
