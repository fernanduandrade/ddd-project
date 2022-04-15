using Domain.Entities;
using FluentValidation;

namespace Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor fornecer um nome")
                .NotNull().WithMessage("Por favor fornecer um nome");
            
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor fornecer um email")
                .NotNull().WithMessage("Por favor fornecer um email");

            RuleFor(c =>c.Password)
                .NotEmpty().WithMessage("Por favor fornecer uma senha")
                .NotNull().WithMessage("Por favor fornecer uma senha");
        }
    }
}
