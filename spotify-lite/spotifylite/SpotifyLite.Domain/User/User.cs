using FluentValidation;
using SpotifyLite.Domain.User.Rules;
using SpotifyLite.Domain.User.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Domain.User
{
    public class User
    {
        public Guid Id { get; set; }

        public String Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Photo { get; set; }
        public CPF CPF { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public virtual IList<UserFavoriteMusic> FavoriteMusics { get; set; }

        public void Validate() => new UserValidator().ValidateAndThrow(this);
    }
}
