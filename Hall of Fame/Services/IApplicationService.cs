using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hall_of_Fame.DTO;
using Hall_of_Fame.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hall_of_Fame.Services
{
    public interface IApplicationService
    {
        Task<PersonDTO> Get();
        Task<PersonDTO> GetId(int id);
        Task<PersonDTO> AddPerson(Person person);
       // Task<PersonDTO> EditPerson(Person person, int id);

    }
}
