using System;
using System.Collections.Generic;
using System.Text;

namespace Cuisine
{
    public class Plat
    {
        public int PlatId { get; set; }
        public string TypePlat { get; set; }
        public int NbrBouchee { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Plat plat &&
                   TypePlat == plat.TypePlat &&
                   NbrBouchee == plat.NbrBouchee;
        }

        public override string ToString()
        {
            return $" Le plat {PlatId}({TypePlat}) est prêt !";
        }
    }
}
