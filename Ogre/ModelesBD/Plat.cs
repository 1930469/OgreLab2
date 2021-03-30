using System;
using System.Collections.Generic;

#nullable disable

namespace Ogre.ModelesBD
{
    public partial class Plat
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
            return $" Le plat ({TypePlat}) est prêt !";
        }


    }
}
