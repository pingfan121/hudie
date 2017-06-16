package pf.com.butterfly.module.advise;

import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import pf.com.butterfly.MainActivity;
import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.Protocols.advise_cteate_req;
import pf.com.butterfly.message.net.IMsgResult;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.util.HDLog;

/**
 * Created by admin on 2017/3/13.
 */
public class AdviseHead extends AppBaseViewControl
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

    protected void initValue()
    {
        title="建议";
        layout=R.layout.advise_head;
    }


    private EditText et;

    @Override
    public void initControl()
    {
        et=(EditText)view.findViewById(R.id.et_advise);

        view.findViewById(R.id.btn_tijiao).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OnTiJiao();
            }
        });
    }


    public void OnTiJiao()
    {
       // Toast.makeText(ModuleManager.main,"点击了提交按钮...",Toast.LENGTH_SHORT).show();

        String str = et.getText().toString();

        if(str.equals(""))
        {
            Toast.makeText(MainActivity.main,"填一些建议,让世界变得更美好。",Toast.LENGTH_SHORT).show();
            return;
        }

        advise_cteate_req req=new advise_cteate_req();
        req.content=str;
        req.userid="111111";
        NetManager.SendMsg(req,msg_result);


    }
    private IMsgResult msg_result=new IMsgResult()
    {
        @Override
        public void onError(int err, String msg)
        {
            HDLog.Toast(msg);
        }

        @Override
        public void onResult(MsgBase msg)
        {
            HDLog.Toast("建议提交成功,谢谢您的支持");
            AdviseHead.getInstance().CleanText();
        }
    };

    public void CleanText()
    {
        et.setText("");
        et.setHint("感谢您的建议 ,您还可以继续提建议吖。");

    }

}
