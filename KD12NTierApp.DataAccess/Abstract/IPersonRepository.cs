using KD12NTierApp.Core.DataAccess.Abstract;
using KD12NTierApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD12NTierApp.DataAccess.Abstract
{
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
