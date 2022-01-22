using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.NetBootcamp.Odev2.ValidationRules.Rules
{
    public class IsDigitValidationRule : IValidationRule
    {
        public bool IsValid(string str)
        {
            return str.Any(x => Char.IsDigit(x));//Sifrede rakam var mi?
        } 
    }
}
