﻿using DealProject.Application;
using FluentValidation;
using Shared.FluentValidation.Extensions;

namespace DealProject;

public class LendDebtDtoValidator : AbstractValidator<LendDebtDto>
{
    public LendDebtDtoValidator()
    {
        RuleFor(x => x.Login)
           .NotEmptyWithMessage()
           .MaximumLengthWithMessage(128);

        RuleFor(x => x.Sum)
            .GreaterThanWithMessage(0);

        RuleFor(x => x.Begin)
            .LessThanOrEqualToWithMessage(DateTime.UtcNow);

        RuleFor(x => x.End)
            .GreaterThanWithMessage(x => x.Begin)
            .When(x => x.End.HasValue);
    }
}