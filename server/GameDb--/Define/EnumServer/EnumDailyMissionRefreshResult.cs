using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Define.EnumServer
{
    public enum EnumDailyMissionRefreshResult
    {
        normal = 0,         // 正常
        full = 1,           // 必满
        not_full = 2,       // 必不满
    }
}
