using KD12NTierApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD12NTierApp.Bussiness.Abstract
{
    public interface IPersonService
    {
        Task<bool> Add(Person entity);
        Task<bool> AddRange(List<Person> entities);
        Task<bool> Update(Person entity);
        Task<bool> Delete(Person entity);
        Task<List<Person>> GetAll();
        Task<Person> GetById(int id);
    }
}
