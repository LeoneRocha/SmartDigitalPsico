﻿using FluentValidation;
using SmartDigitalPsico.Model.Entity.Domains;

namespace SmartDigitalPsico.Business.Validation.SystemDomains
{
    public class RoleGroupValidator : AbstractValidator<RoleGroup>
    {
        public RoleGroupValidator()
        {
            RuleFor(entity => entity.Description)
                .NotNull().NotEmpty()
                .WithMessage("ErrorValidator_Description_Null");

            RuleFor(entity => entity.Language)
                .NotNull().NotEmpty()
                .WithMessage("ErrorValidator_Language_Null")
                .MaximumLength(10)
                .WithMessage("O Language não pode ultrapassar {MaxLength} carateres.");
        }
    }
}
