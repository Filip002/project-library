using FluentValidation;
using LibraryAPI.Entities;

namespace LibraryAPI.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(LibraryDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Custom((value, context) =>
                {
                    bool isEmailInUse = dbContext.Users.Any(u => u.Email == value);
                    if(isEmailInUse)
                    {
                        context.AddFailure("Email", "This email address is taken");
                    }
                });

            RuleFor(x => x.Password)
                .MinimumLength(8);

            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password);
        }
    }
}
