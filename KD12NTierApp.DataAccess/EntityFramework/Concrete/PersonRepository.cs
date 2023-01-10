using KD12NTierApp.DataAccess.Abstract;
using KD12NTierApp.DataAccess.EntityFramework.Context;
using KD12NTierApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD12NTierApp.DataAccess.EntityFramework.Concrete
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(KD12NTierAppDbContext kD12NTierAppDbContext) : base(kD12NTierAppDbContext)
        {
        }
    }
}
