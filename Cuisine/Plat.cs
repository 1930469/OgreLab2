using System;
using System.Collections.Generic;
using System.Text;

namespace Cuisine
{
    class Plat
    {
        public int PlatId { get; set; }
        public string TypePlat { get; set; }
        public int NbrBouchee { get; set; }
        public override string ToString()
        {
            return $" Le plat {PlatId}({TypePlat}) est prêt !";
        }
    }
}
