using Clean.Architecture.Contracts.AuthContracts;
using FluentValidation;

namespace Clean.Architecture.Contracts.Validators.AuthContracts
{
    public class AuthRequestValidator : AbstractValidator<AuthRequest>
    {
        public AuthRequestValidator() 
        {
            RuleFor(c => c.Username)
                .NotEmpty()
                .Length(5, 20).WithMessage("Login deve ter entre 5 e 20 caracteres!");

            RuleFor(c => c.Password)
                .NotEmpty()
                .Length(5, 10).WithMessage("Password deve conter entre 5 e 10 caracteres!");
        }
    }
}
