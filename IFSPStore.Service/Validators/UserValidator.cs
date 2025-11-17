using FluentValidation;
using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IFSPStore.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            //done
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome do usuário obrigatório!");
            RuleFor(c => c.Login)
                .NotEmpty().WithMessage("Login do usuário obrigatório!");
            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("Email do usuário inválido!");
            RuleFor(c => c.Password)
               .NotEmpty().WithMessage("Senha do usuário obrigatória!")
               .MinimumLength(8).WithMessage("Senha do usuário mínimo 8 caracteres!")
               .MaximumLength(16).WithMessage("Senha do usuário máximo 16 caracteres!")
               .Matches(@"[A-Z]+").WithMessage("Senha do usuário deve conter letras maiusculas!")
               .Matches(@"[a-z]+").WithMessage("Senha do usuário deve conter letras minusculas!")
               .Matches(@"[0-9]+").WithMessage("Senha do usuário deve conter números!")
               .Matches(@"[\!\?\*\.]+").WithMessage("Senha do usuário deve conter (! e/ou ? e/ou * e/ou .)!");
            RuleFor(c => c.RegisterDate)
                .NotEmpty().WithMessage("Data de registro do usuário obrigatório!");
            RuleFor(c => c.LoginDate)
                .NotEmpty().WithMessage("Data de login do usuário obrigatório!");
            RuleFor(c => c.IsActive)
                .NotEmpty().WithMessage("Estado de ativação do usuário obrigatório!");

        }
    }
}
