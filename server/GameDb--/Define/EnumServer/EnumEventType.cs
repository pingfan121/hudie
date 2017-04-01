using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Define.EnumServer
{
    public enum EnumEventType
    {
        unknown = 0,

        tiker_expire,
        tiker_period,

        user = 1000,


        // 数据库事件
        db_request = user + 100,
        db_result,

        // 用户事件
        user_relogin,

        // 地图事件
        scene_enter_map,
        scene_leave_map,
        scene_enter_area,
        scene_leave_area,
        scene_enter_grid,
        scene_leave_grid,
        scene_dialog_click,
        scene_team_clone_ready,

        // 单位事件
        unit_move_arrive,
        unit_attacked,
        unit_dead,
        unit_relive,
        unit_sprite_click,
        unit_dialog_click,

        // 角色事件
        role_enter_game,
        role_leave_game,
        role_transfer,
        role_move_complete,
        role_dead,
        role_script_relive,
        role_level_change,
        role_sign_day,
        role_login_day,
        role_online_award,
        role_enter_clone,
        role_guild_join,
        role_guild_change,
        role_guild_offer,
        role_team_join,
        role_add_friend,
        role_daily_task,
        role_trunk_task,
        role_map_change,
        role_upgrade_officer,
        role_have_resources,
        role_fight_power_change,
        role_suit_change,
        role_del,  //删除事件
        role_vip_pay,
        role_daily_first_recharge,
        role_magic_matrix,
        role_worship_city_master,
        role_seek_treasure,

        // 道具事件
        item_equipment_forge,
        item_equipment_equip,
        item_activate_rune,
        item_compound_bead,
        item_smelter_wolf, // 狼牙(魂珠)
        item_smelter_shield, // 护盾
        item_smelter_dragon, // 龙心(宝石)
        item_upgrade_wing, // 翅膀
        item_task,
        item_use,
        item_move,
        item_get,
        item_lose,

        // 脚本事件
        script_file_change,
        script_state_change,

        // 刷新事件
        refresh_daily,

        // WEB事件
        web_msg,
        web_error,
        datafile_change,
    }
}
