using KD12NTierApp.Bussiness.Abstract;
using KD12NTierApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KD12NTierApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson([FromBody]Person person)
        {
            try
            {
                await _personService.Add(person);
            }
            catch (Exception)
            {

                return NotFound();
            }

            return CreatedAtAction("GetPerson", new { Id = person.Id }, person);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _personService.GetById(id);
            if(person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPerson()
        {
            var personList = await _personService.GetAll();

            if(personList == null)
            {
                return NotFound();
            }
            return Ok(personList);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var deletePerson = await _personService.GetById(id);
            if (deletePerson == null)
            {
                return NotFound();
            }
            await _personService.Delete(deletePerson);
            return Ok(deletePerson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> UpdatePerson(int id,Person person)
        {
            var updatePerson = await _personService.GetById(id);
            if (updatePerson == null)
            {
                return NotFound();
            }
            updatePerson.Name = person.Name;
            updatePerson.Surname = person.Surname;
            updatePerson.TcNo = person.TcNo;
            await _personService.Update(updatePerson);
            return Ok(updatePerson);
        }




    }
}
