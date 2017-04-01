using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Define.EnumServer
{
    public enum EnumUserStateProgressType
    {
        none = 0,

        waiting = 1,
        complete = 2,
    }

    public enum EnumUserStateType
    {
        // 未知状态, 一般用于初始值
        unknown = 0,

     
        role_enter_game = 309,
        role_leave_game = 310,

        game_idel = 401,
        game_dead = 402,
        game_move = 403,
        game_change_map = 404,
        game_trans_pos = 405,
        game_relive = 406,

        game_trade = 407, // 交易
        game_stall = 408, // 摆摊

        state_all,
    }

    public enum EnumUserStateOptType
    {
        unknown,

        enter,
        leave,
    }
}
