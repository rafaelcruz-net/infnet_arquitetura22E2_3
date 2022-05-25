using FluentValidation;
using SpotifyLite.Domain.User.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpotifyLite.Domain.User.Rules
{
    public class EmailValidator : AbstractValidator<Email>
    {
        private const string Pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        private bool BeAEmailValid(string valor) => Regex.IsMatch(valor, Pattern);
        public EmailValidator()
        {
            RuleFor(x => x.Value).NotEmpty().Must(BeAEmailValid).WithMessage("Email invalido");
        }

    }
}
