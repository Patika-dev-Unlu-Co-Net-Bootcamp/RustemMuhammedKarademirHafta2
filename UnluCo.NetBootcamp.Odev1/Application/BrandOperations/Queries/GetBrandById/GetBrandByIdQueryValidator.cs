using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.NetBootcamp.Odev2.BrandOperations.GetBrandById
{
    public class GetBrandByIdQueryValidator : AbstractValidator<GetBrandByIdQuery>
    {
        public GetBrandByIdQueryValidator()
        {
            RuleFor(command => command.brandId).GreaterThan(0);//BrandId sifirdan buyuk olmali
        }
    }
}
