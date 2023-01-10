using KD12NTierApp.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD12NTierApp.Entities.Abstract
{
    public interface IPerson : IBaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TcNo { get; set; }

    }
}
