using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Domain.User.ValueObject
{
    public class CPF
    {
        public CPF()
        {

        }
        public CPF(string value)
        {
            this.Value = value?.Replace(".", "").Replace("-", "") ?? throw new ArgumentNullException(nameof(CPF));
        }

        public String Value { get; set; }

        public string FormatValue => Format(this.Value);

        private string Format(string value) => Convert.ToInt64(value).ToString(@"000\.000\.000\-00");

    }
}
