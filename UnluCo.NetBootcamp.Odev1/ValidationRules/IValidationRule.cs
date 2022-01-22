using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.NetBootcamp.Odev2.ValidationRules
{
    public interface IValidationRule
    {
        bool IsValid(string str);
    }
}
