using System.Collections.Generic;
using System.Threading.Tasks;
using Hall_of_Fame.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hall_of_Fame.Services
{
    public interface IApplicationService
    {
        Task<ActionResult<IEnumerable<Person>>> Get();
        Task<ActionResult<Person>> GetId(long id);
        Task<ActionResult<Person>> AddPerson(Person person);
        Task<ActionResult<Person>> EditPerson(Person person);
        Task<ActionResult<Person>> DeletePerson(long id);
    }
}
