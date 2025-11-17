using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validators
{
    public class CustomerValidador : AbstractValidator<Customer>
    {
        public CustomerValidador()
        {
            //done
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome do cliente obrigatório!");
            RuleFor(c => c.Document)
                .NotEmpty().WithMessage("Documento do cliente obrigatório!");
            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Endereço do cliente obrigatório!");
            RuleFor(c => c.District)
                .NotEmpty().WithMessage("Bairro do cliente obrigatório!");
            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Cidade do cliente obrigatório!");
        }
    }
}
