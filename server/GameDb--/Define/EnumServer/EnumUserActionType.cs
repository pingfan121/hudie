using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Define.EnumServer
{
    public enum EnumUserActionType
    {
        none,

        pos_move,
        pos_trans,
        map_change,
        
        attack,
        attack_monster,
        attack_role,

        action_all
    }
}
