using FluentValidation;
using SmartDigitalPsico.Model.Entity.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Business.Validation
{
    public class GenderValidator : AbstractValidator<Gender>
    {
        //https://docs.fluentvalidation.net/en/latest/start.html
        public GenderValidator()
        {
            RuleFor(entity => entity.Description).NotNull().WithMessage("A descrição não pode ser vazia.");
            RuleFor(entity => entity.Language).NotNull().WithMessage("O Language não pode ser vazia.");            
        }
    }
}
