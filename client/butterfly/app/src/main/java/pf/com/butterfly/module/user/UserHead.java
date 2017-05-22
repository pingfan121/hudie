package pf.com.butterfly.module.user;

import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseViewControl;

/**
 * Created by admin on 2017/4/8.
 */
public class UserHead extends AppBaseViewControl
{

    private static UserHead _instance;

    public static UserHead getInstance()
    {
        if(_instance==null)
        {
            _instance=new UserHead();
        }

        return _instance;
    }

    @Override
    protected void initValue()
    {
        super.initValue();

        title="用户";

        layout= R.layout.user_head;
    }

}
