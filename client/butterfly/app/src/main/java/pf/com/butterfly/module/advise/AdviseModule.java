package pf.com.butterfly.module.advise;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.ViewGroup;

import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.module.benefit.BenefitDetail;
import pf.com.butterfly.module.benefit.BenefitDonation;
import pf.com.butterfly.module.benefit.BenefitFalsify;
import pf.com.butterfly.module.benefit.BenefitHead;
import pf.com.butterfly.module.benefit.BenefitProof;

/**
 * Created by admin on 2017/3/13.
 */
public class AdviseModule extends AppBaseFragment {



    @Override
    protected void initView(LayoutInflater inflater, ViewGroup container,
                            Bundle savedInstanceState)
    {

        view = inflater.inflate(R.layout.module_advise, container, false);


        //蝴蝶主页
        AdviseHead.getInstance().init(this,view);

        //显示一个页面
        SetFirstControl(AdviseHead.getInstance());
    }

}