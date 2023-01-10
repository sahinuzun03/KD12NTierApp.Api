using KD12NTierApp.Bussiness.Abstract;
using KD12NTierApp.DataAccess.Abstract;
using KD12NTierApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD12NTierApp.Bussiness.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> Add(Person entity)
        {
            await _personRepository.Add(entity);
            return true;
        }

        public async Task<bool> AddRange(List<Person> entities)
        {
            await _personRepository.AddRange(entities);
            return true;
        }

        public async Task<bool> Delete(Person entity)
        {
            return await _personRepository.Delete(entity);
        }

        public async Task<List<Person>> GetAll()
        {
            return await _personRepository.GetAll();
        }

        public async Task<Person> GetById(int id)
        {
            return await _personRepository.GetById(id); 
        }

        public async Task<bool> Update(Person entity)
        {
            return await _personRepository.Update(entity);
        }
    }
}
