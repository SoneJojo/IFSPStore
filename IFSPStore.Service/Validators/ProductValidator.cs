using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //done
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome do produto obrigatório!");
            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Preço do produto obrigatório!")
                .GreaterThan(0).WithMessage("Preço do produto deve ser maior que zero!");
            RuleFor(c => c.Quantity)
               .NotEmpty().WithMessage("Quantidade do produto obrigatório!")
               .GreaterThanOrEqualTo(0).WithMessage("Quantidade do produto deve ser pelo menos zero!");
            RuleFor(c => c.PurchaseDate)
               .NotEmpty().WithMessage("Data de compra do produto obrigatório!");
            RuleFor(c => c.SalesUnit)
               .NotEmpty().WithMessage("Unidade do produto obrigatório!");
            RuleFor(c => c.Category)
               .NotEmpty().WithMessage("Categoria do produto obrigatório!");
        }
    }
}
