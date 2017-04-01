namespace GameServer.Define.EnumServer
{
    public enum EnumItemOperationType
    {
        unknown,
        normal,
        use,

        // 补充道具获得原因
        pick_up, // 物品拾取
        drop, // 物品掉落
        shop_buy, // 物品购买
        mall_buy, // 物品购买
        repo, // 物品回购
        trade, // 交易
        mail, // 邮件
        stall, // 摆摊
        compound, // 合成
        forge, // 锻造
        guild, // 帮会
        mission, // 任务
        script, // 脚本
        achievement, // 活动
        cultivation, // 修为值
        sha_cheng, // 沙城奖励
        smelter, // 熔炉
        wing, // 翅膀
        mine,
        online_award,
        blood_sacrifice_recycle_head,// 血祭回收
        vip_lev,
        vip_day,
        recycle, // 回收
        inlay, // 镶嵌
        special, // 特惠礼包
        integral, // 积分兑换
        skill, // 技能天人合一
        seven_days, // 七日奖励
        athletics, // 竞技奖励
        recharge, // 首充及每日充值
        mars, // 战神
        transfer, // 传送
        blood_sacrifice_activate,// 血祭激活
        command, // GM命令
        daily_mission, // 日常任务消耗
        treasure_chest, // 宝箱使用获得
        popular_boss, //全民BOSS
        time_limit, //限时购买
        beheaded, //斩首
        copybook_exchange, //字帖兑换
        second_day_login_award, //盲测次日登录奖励
        totem_upgrade, // 图腾升级
        plot_award, // 剧情奖励
        treasure, // 聚宝盆
        privilege,//特权领取
        extension_bind,//推广员小号奖励
        extension_award,//推广员奖励
        crazy_exchange_ingot,//挂机狂欢兑换元宝
        mine_copybook,//挖宝集字
        privilege_360_award,// 360特权奖励
        holiday_online_award,// 庆典活动-在线奖励
    }
}
