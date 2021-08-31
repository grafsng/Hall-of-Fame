using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Hall_of_Fame.DTO;
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
            if (!db.Persons.Any())
            {
                db.Persons.Add(new Person { Name = "Tom"});
                db.Persons.Add(new Person { Name = "Alice"});
                db.SaveChanges();
            }
        }
        
        ///GET api/v1/persons
        ///Возвращает массив объектов типа Person
        public async Task<PersonDTO> Get()
        {
            //if (!_db.Persons.Any())
            //    return NotFound();
            //else
            var get = await db.Persons.ToListAsync();
            return new PersonDTO
            {
                Workers = get
            };
        }

        ///GET api/v1/person/[id]
        ///Возвращает объект типа Person.
        public async Task<PersonDTO> GetId(int id)
        {
            Person person = await db.Persons.Include(item => item.Skills).FirstOrDefaultAsync(x => x.Id == id);

            return new PersonDTO
            {
                Name = person.Name,
                DisplayName = person.DisplayName,
                Skills = person.Skills
            };
        }

        //POST api/v1/person
        //Создаёт нового сотрудника
        public async Task<PersonDTO> AddPerson(Person person)
        {
            //if (person == null)
            //{
            //    return BadRequest();
            //}
            db.Persons.Add(person);
            
            await db.SaveChangesAsync();
            return new PersonDTO
            {
                Name = person.Name,
                DisplayName = person.DisplayName,
                Skills = person.Skills,
                Id = person.Id
            };
            
        }

        ////PUT api/v1/person/[id]
        ////Обновляет данные сотрудника
        //public async Task<ActionResult<Person>> EditPerson(Person person, int id)
        //{
        //    if (person == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (!db.Persons.Any(x => x.Id == id))
        //    {
        //        return NotFound();
        //    }

        //    db.Persons.Attach(person);
        //    db.Entry(person).Property(x => x.Name).IsModified = true;
        //    db.Entry(person).Property(x => x.DisplayName).IsModified = true;
        //    await db.SaveChangesAsync();
        //    return Ok(person);
        //}

        ////DELETE api/v1/person/[id]
        ////Удаляет с указанным id сотрудника из системы.
        //public async Task<ActionResult<Person>> DeletePerson(int id)
        //{
        //    Person person = _db.Persons.Include(item => item.Skills).FirstOrDefault(x => x.Id == id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.Persons.Remove(person);
        //    await _db.SaveChangesAsync();
        //    return Ok(person);
        //}
    }
}
