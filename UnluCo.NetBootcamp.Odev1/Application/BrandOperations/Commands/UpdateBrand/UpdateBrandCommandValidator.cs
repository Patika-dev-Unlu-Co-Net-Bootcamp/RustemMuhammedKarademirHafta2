using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.NetBootcamp.Odev2.BrandOperations.UpdateBrand
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(command => command.brandId).GreaterThan(0);//BrandId sifirdan buyuk olmali
            RuleFor(command => command.Model.BrandName).NotEmpty().MinimumLength(2);
        }
    }
}
