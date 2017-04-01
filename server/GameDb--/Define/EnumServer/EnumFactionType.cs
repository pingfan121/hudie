using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Define.EnumServer
{
    //=========阵营枚举==========
    public enum EnumFactionType
    {
        none = 0, // 无
        anyone = 1, // 所有
        human = 2, // 人类
        guild = 3, // 工会
        camp_a = 4, // 阵营A
        camp_b = 5, // 阵营B
    }
}
