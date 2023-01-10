using KD12NTierApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD12NTierApp.Core.Entities.Abstract
{

    //loose coupling : Soyutlamanın arttırılması 
    public interface IBaseEntity : IBase
    {
        int Id { get; set; }
        Status Status { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        string? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
