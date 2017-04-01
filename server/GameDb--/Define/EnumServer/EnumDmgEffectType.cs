using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Define.EnumServer
{
    public enum EnumDmgEffectType
    {
        none = 1,
        harmful = 2,
        helpful = 3,//buf
        inhert_buffer = 4,
        inhert_trap = 5,
//         lock_pos = 6,
    }
}
