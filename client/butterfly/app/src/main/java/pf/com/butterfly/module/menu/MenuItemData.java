package pf.com.butterfly.module.menu;

import android.view.View;

/**
 * Created by admin on 2017/3/12.
 */
public class MenuItemData
{
    public int icon;//图片
    public String title;//标题
    public String modname;//点击显示的模块

    public void init(int icon,String title, String modname) {
        this.icon = icon;
        this.title = title;
        this.modname = modname;
    }
}
