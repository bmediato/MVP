namespace Domain.Commands.v1.User.Save;

public class UserSaveCommandValidator : AbstractValidator<UserSaveCommand>
{
    public UserSaveCommandValidator()
    {
        RuleFor(x => x.UserName)
               .NotEmpty().WithMessage("O nome de usuário é obrigatório")
               .Length(3, 50).WithMessage("O nome de usuário deve ter entre 3 e 50 caracteres.");

        RuleFor(x => x.Email)
               .NotEmpty().WithMessage("O e-mail é obrigatório.")
               .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("E-mail inválido.");

        RuleFor(x => x.Password)
               .NotEmpty().WithMessage("A senha é obrigatória.")
               .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");

        RuleFor(x => x.Address)
                .NotEmpty().WithMessage("O endereço é obrigatório.")
                .Length(10, 100).WithMessage("O endereço deve ter entre 10 e 100 caracteres.");

        RuleFor(x => x.PhoneNumber)
               .NotEmpty().WithMessage("O número de telefone é obrigatório.")
               .Matches(@"^\+\d{1,3}\s\d{1,14}$").WithMessage("Número de telefone inválido.");

    }
}
