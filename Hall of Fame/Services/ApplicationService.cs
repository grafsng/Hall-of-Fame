using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hall_of_Fame.Models;
using Hall_of_Fame.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hall_of_Fame.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationContext db;
        public ApplicationService(ApplicationContext context)
        {
            db = context;
            
        }

        ///GET api/v1/persons
        ///Возвращает массив объектов типа Person
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            return await db.Persons.Include(item => item.Skills).ToListAsync();
        }


        ///GET api/v1/person/[id]
        ///Возвращает объект типа Person.
        /// 
        public async Task<ActionResult<Person>> GetId(long id)
        {
            Person person = await db.Persons.Include(item => item.Skills).FirstOrDefaultAsync(x => x.Id == id);

            return person;
        }

        ///POST api/v1/person
        ///Создаёт нового сотрудника
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            
            db.Persons.Add(person);
            
            db.SaveChanges();

            return person;
        }

        ///PUT api/v1/person/[id]
        ///Обновляет данные сотрудника
        public async Task<ActionResult<Person>> EditPerson(Person person)
        {
            db.Update(person);
            db.SaveChanges();
            return person;
        }

        ///DELETE api/v1/person/[id]
        ///Удаляет с указанным id сотрудника из системы.
        public async Task<ActionResult<Person>> DeletePerson(long id)
        {
            Person person = db.Persons.Include(item => item.Skills).FirstOrDefault(x => x.Id == id);
            
            db.Persons.Remove(person);
            db.SaveChanges();
            return person;
        }
    }
}
