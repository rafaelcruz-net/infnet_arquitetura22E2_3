using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Domain.Album.ValueObject
{
    public class Band
    {
        public Band()
        {

        }
        public Band(String name)
        {
            this.Name = name;
        }

        public String Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
