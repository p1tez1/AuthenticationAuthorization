using BLL.Features.Users.RegistUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Features.Users.ValidationUsers
{
    public class RegistUserValidator : AbstractValidator<RegistUserComand>
    {
        public RegistUserValidator()
        {
            RuleFor(u => u.name)
                .NotEmpty()
                .WithMessage("You name can`t be empty")
                .MaximumLength(30)
                .WithMessage("The lengt of you name can`t be more than 20 characters long");

            RuleFor(u => u.lastname)
                .NotEmpty()
                .WithMessage("You last name can`t be empty")
                .MaximumLength(30)
                .WithMessage("The lengt of you lastname can`t be more than 20 characters long");

            RuleFor(u => u.email)
                .NotEmpty()
                .WithMessage("Your email can't be empty.")
                .EmailAddress()
                .WithMessage("This email don't exist.")
                .Matches(@"^[^@\s]+@gmail\.com$")
                .WithMessage("Email must end with @gmail.com.");

            RuleFor(u => u.password)
                .NotEmpty()
                .WithMessage("You password can`t be empty");

            RuleFor(u => u.additionalquestion)
                .NotEmpty()
                .WithMessage("Aditional question coud be filled (i`ts for you save)");
        }
    }
}
