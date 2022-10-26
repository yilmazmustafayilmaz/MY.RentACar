using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("Ad alanı 2 karakterden az olamaz");
            RuleFor(x => x.ModelYear).NotEmpty().GreaterThan(0);
            RuleFor(x => x.DailyPrice).GreaterThanOrEqualTo(1000).When(x => x.BrandId == 1);
            RuleFor(x => x.Name).Must(StartWithA).WithMessage("Araba ismi A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
