using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Define.EnumServer
{
    public enum EnumRangeType
    {
        none = 0, // 未知  
        single = 1, // 点
        line = 2, // 线
        square = 3, // 圆形
        fan = 4, // 扇形
    }
}
