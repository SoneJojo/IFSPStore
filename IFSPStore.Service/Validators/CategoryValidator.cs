using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        //done
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome da categoria obrigatório!");
        }
    }
}
