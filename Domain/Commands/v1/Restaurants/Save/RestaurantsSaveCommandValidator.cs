namespace Domain.Commands.v1.Restaurants.Save;

public class RestaurantsSaveCommandValidator : AbstractValidator<RestaurantsSaveCommand>
{
    public RestaurantsSaveCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome do restaurante é obrigatório.")
            .Length(3, 100).WithMessage("O nome do restaurante não pode ter mais de 100 caracteres.");

        RuleFor(x => x.Category)
            .IsInEnum().WithMessage("Categoria inválida.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição é obrigatória.")
            .MaximumLength(500).WithMessage("A descrição não pode ter mais de 500 caracteres.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("O endereço é obrigatório.")
            .MaximumLength(300).WithMessage("O endereço não pode ter mais de 200 caracteres.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("O número de telefone é obrigatório.")
            .Matches(@"^\+\d{1,3}\s\d{1,14}$").WithMessage("Número de telefone inválido.");

        RuleFor(x => x.Logo)
            .NotEmpty().WithMessage("O logo é obrigatório.");

        RuleFor(x => x.Banner)
            .NotEmpty().WithMessage("O banner é obrigatório.");

        RuleForEach(x => x.Dishes).SetValidator(new DishesValidator());
    }
}

public class DishesValidator : AbstractValidator<Dishes>
{
    public DishesValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome do prato é obrigatório.")
            .Length(3, 100).WithMessage("O nome do prato deve ter entre 3 e 100 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição do prato é obrigatória.")
            .MaximumLength(500).WithMessage("A descrição do prato não pode ter mais de 500 caracteres.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("O preço é obrigatório.")
            .Matches(@"^\d+(\.\d{1,2})?$").WithMessage("O preço deve ser um valor numérico com até duas casas decimais.");

        RuleFor(x => x.FoodType)
           .IsInEnum().WithMessage("Tipo de comida inválida.");

        RuleFor(x => x.Image)
            .NotEmpty().WithMessage("A imagem é obrigatória.");
    }
}
