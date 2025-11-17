using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validators
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            //done
            RuleFor(c => c.SaleDate)
                .NotEmpty().WithMessage("Data da venda obrigatório!");
            RuleFor(c => c.SaleTotal)
                .NotEmpty().WithMessage("Total da venda obrigatório!")
                .GreaterThanOrEqualTo(0).WithMessage("Total da venda deve ser pelo menos zero!");
            RuleFor(c => c.Salesman)
                .NotEmpty().WithMessage("Vendedor obrigatório!");
            RuleFor(c => c.Customer)
                .NotEmpty().WithMessage("Cliente obrigatório!");
            RuleFor(c => c.SaleItens)
                .NotEmpty().WithMessage("Itens da compra obrigatórios!");
        }
    }

    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            //done
            RuleFor(c => c.Sale)
                .NotEmpty().WithMessage("Venda obrigatório!");
            RuleFor(c => c.Product)
                .NotEmpty().WithMessage("Produto obrigatório!");
            RuleFor(c => c.Quantity)
                .NotEmpty().WithMessage("Quantidade de itens vendidos obrigatório!")
                .GreaterThan(0).WithMessage("Total de itens vendidos deve ser maior que zero!");
            RuleFor(c => c.UnitPrice)
                .NotEmpty().WithMessage("Preço unitário obrigatório!")
                .GreaterThan(0).WithMessage("Preço unitário deve ser maior que zero!");
            RuleFor(c => c.TotalPrice)
                .NotEmpty().WithMessage("Preço total obrigatório!")
                .GreaterThanOrEqualTo(0).WithMessage("Preço total deve ser pelo menos zero!");
            
        }
    }
}
