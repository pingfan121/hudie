package pf.com.butterfly.module.benefit;


import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.ViewGroup;

import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.module.title.TitleModule;


/**
 * A fragment with a Google +1 button.
 */
public class BenefitModule extends AppBaseFragment {



    @Override
    protected void initView(LayoutInflater inflater, ViewGroup container,
                            Bundle savedInstanceState)
    {

        view = inflater.inflate(R.layout.module_benefit, container, false);

        //蝴蝶主页
        BenefitHead.getInstance().init(this,view);
        BenefitDetail.getInstance().init(this,view);
        BenefitProof.getInstance().init(this,view);
        BenefitFalsify.getInstance().init(this,view);
        BenefitDonation.getInstance().init(this,view);

        //显示一个页面
        SetFirstControl(BenefitHead.getInstance());
    }

}
