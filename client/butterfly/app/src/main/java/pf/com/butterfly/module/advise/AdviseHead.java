package pf.com.butterfly.module.advise;

import android.view.View;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import pf.com.butterfly.ModuleManager;
import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseControl;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.message.Protocols.advise_cteate_req;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.benefit.BenefitHeadItemAdapter;
import pf.com.butterfly.module.title.TitleModule;

/**
 * Created by admin on 2017/3/13.
 */
public class AdviseHead extends AppBaseControl
{
    private static AdviseHead _instance;

    public static AdviseHead getInstance()
    {
        if(_instance==null)
        {
            _instance=new AdviseHead();
        }

        return _instance;
    }

    private EditText et;

    @Override
    public void init(AppBaseFragment appfragment, View father)
    {
        super.init(appfragment,father);

        view=father.findViewById(R.id.advise_head);

        et=(EditText)father.findViewById(R.id.et_advise);

        father.findViewById(R.id.btn_tijiao).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OnTiJiao();
            }
        });
    }

    @Override
    public void SetTitleView()
    {
        TitleModule.getInstance().SetTitle("建议");
    }

    public void OnTiJiao()
    {
       // Toast.makeText(ModuleManager.main,"点击了提交按钮...",Toast.LENGTH_SHORT).show();

        String str = et.getText().toString();

        if(str.equals(""))
        {
            Toast.makeText(ModuleManager.main,"填一些建议,让世界变得更美好。",Toast.LENGTH_SHORT).show();
            return;
        }

        advise_cteate_req req=new advise_cteate_req();
        req.content=str;
        req.userid="111111";
        NetManager.SendMsg(req);


    }

    public void CleanText()
    {
        et.setText("");
        et.setHint("感谢您的建议 ,您还可以继续提建议吖。");

    }

}
