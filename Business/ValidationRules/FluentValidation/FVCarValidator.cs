using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FVCarValidator:AbstractValidator<Car>
    {
        public FVCarValidator()
        {
            RuleFor(c=>c.Name).MinimumLength(2);
            RuleFor(c=>c.ModelYear.ToString()).Length(4).WithMessage(Messages.ModelYearMustBeEnteredAsFourCharacters);
            RuleFor(c=>c.DailyPrice).GreaterThan(0);
            RuleFor(c=>c.FindeksPoint).GreaterThanOrEqualTo(0);
            RuleFor(c=>c.FindeksPoint).LessThanOrEqualTo(1900);
        }
    }
}
