using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Define.EnumServer
{
    public enum EnumShaChengState
    {
        normal = 0,             // 非活动阶段，一切攻城动作无效
        no_attack = 1,          // 未攻打阶段，一切攻城动作无效
        stop = 2,               // 终止阶段，一切攻城动作无效

        attack_statue = 3,      // 攻打雕像阶段，只能攻击雕像
        palace_safe = 4,        // 皇宫占领保护阶段，可以攻击皇宫墙壁，皇宫不可被占领
        palace_no_master = 5,   // 皇宫无主阶段，皇宫可被占领
        palace_occupy = 6,      // 皇宫占领阶段        
    }
}