using FluentValidation;

namespace FluentValidationDemo.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("نام اجباری است")
                .Length(2, 50).WithMessage("نام باید بین ۲ تا ۵۰ کاراکتر باشد");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("نام خانوادگی اجباری است");

            RuleFor(x => x.Age)
                .InclusiveBetween(18, 60).WithMessage("سن باید بین ۱۸ تا ۶۰ سال باشد");

            RuleFor(x => x.Email)
                .NotEmpty().EmailAddress().WithMessage("ایمیل معتبر وارد کنید");
        }
    }
}
