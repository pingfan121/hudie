package pf.com.butterfly.base;

import android.view.View;

/**
 * Created by admin on 2017/3/3.
 */
public class AppBaseControlF
{
    public AppBaseFragment fragment=null;
    public View fatherView;

    public void init(AppBaseFragment appfragment)
    {
        fragment=appfragment;

        fatherView=fragment.getFatherView();
    }



}
