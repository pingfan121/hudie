using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameServer.Define.EnumServer
{
    public enum EnumTriggerType
    {
        none = 0,
        impact_value = 1,
        impact_ration = 2,
        add_buffer = 3,
        call_pet = 4,
        set_fire_trap = 5,
        use_skill = 6,
        map_evictions = 7, // 野蛮冲撞
        map_trans = 8, // 回城传送
        map_trans_random = 9, // 随机传送
        kill_pet = 10,
        learn_skill = 11,
        special_buf = 12,
        exchange_item = 13, // 物品兑换
        exchange_fashion = 14,
        buffer_valid_data = 15, // 修改有效性
        map_evictions2 = 16, // 抗拒火环
        world_prosperity = 18, // 世界繁荣度
        use_wneg_item = 19, // 祝福油使用
        vip_poe_level = 20, //vip体验等级
        use_mars_item = 21, // 战神物品
        use_treasure_chest = 22, // 宝箱物品
        summon_random_boss = 23, // 随机召唤boss
        holy_beast_upgrade = 24, // 圣兽升级
        wing_upgrade = 25, // 圣直升二阶翅膀符兽升级
        role_upgrade = 26, // 直升1级丹
        role_rename = 27, // 改名卡
        yb_recharge = 28, // 充值元宝
        impact_value_notice = 29, // 公告类数值物品
        privulege_card = 30,  //特权卡
        map_trans_specific = 31, // 传送到指定地图
        map_evictions3 = 32, // 擒龙手
        guild_red = 33, // 帮会红包使用
        item_collect = 34, // 收藏类物品
    }
}
