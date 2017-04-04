package pf.com.butterfly.module.register;

import android.os.Message;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.google.gson.Gson;

import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseControl;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.http.BmobHttp;
import pf.com.butterfly.message.Protocols.register_req;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.title.TitleModule;
import pf.com.butterfly.util.HDLog;

/**
 * Created by admin on 2017/3/3.
 */
public class RegisterHead extends AppBaseViewControl
{
    private static RegisterHead _instance;

    public static RegisterHead getInstance()
    {
        if(_instance==null)
        {
            _instance=new RegisterHead();
        }
        return _instance;
    }

    protected void initValue()
    {
        title="注册";
        layout=R.layout.register_head;
    }


    private EditText et_mobile;
    private EditText et_password;
    private EditText et_nickname;
    private EditText et_verify;
    private Button btn_register;
    private Button btn_verify;

    private  BmobHttp http;


    @Override
    public void initControl()
    {

        et_mobile=(EditText)view.findViewById(R.id.et_tel);
        et_password=(EditText)view.findViewById(R.id.et_pass);
        et_nickname=(EditText)view.findViewById(R.id.et_name);
        et_verify=(EditText)view.findViewById(R.id.et_verify);

        btn_register=(Button) view.findViewById(R.id.btn_register);

        btn_register.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OnRegisterBtn();
            }
        });

        btn_verify=(Button) view.findViewById(R.id.btn_verify);

        btn_verify.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OnVerifyBtn();
            }
        });

        view.setVisibility(View.INVISIBLE);

        http=new BmobHttp(new IMsgHandler() {
            @Override
            public void onMsgDispose(Message msg) {
                OnMessage(msg);
            }
        });
    }

    //注册按钮事件
    private void OnRegisterBtn()
    {

//        //验证验证验证码
//        reqdata2 data2=new reqdata2();
//        data2.mobilePhoneNumber=et_mobile.getText().toString();
//
//        String str=new Gson().toJson(data2);
//
//        String code=et_verify.getText().toString();
//        //去获取验证码
//        http.send("https://api.bmob.cn/1/verifySmsCode/"+ code,str,2);

        RegisterUser();

    }

    //获取验证码按钮
    private void OnVerifyBtn()
    {
        reqdata data=new reqdata();
        data.mobilePhoneNumber=et_mobile.getText().toString();
        data.template="蝴蝶验证码";

        String str=new Gson().toJson(data);
       //去获取验证码
        http.send("https://api.bmob.cn/1/requestSmsCode",str,1);

    }


    //处理http返回
    private void OnMessage(Message msg)
    {
        if(msg.arg2==-100)
        {
            //请求出现异常了....
            HDLog.Toast(msg.obj.toString());
            return ;
        }

        if(msg.arg2==-99)
        {
            if(msg.arg1==2)
            {

                resdata res =new Gson().fromJson(msg.obj.toString(),resdata.class);

                if(res!=null)
                {
                    HDLog.Toast(GetErrText(res.code));
                    return;
                }

            }

            HDLog.Toast(msg.obj.toString());
            return ;
        }

        if(msg.arg1==1)  //获取验证码
        {
            HDLog.info(msg.obj.toString());
            HDLog.Toast("验证码已发送");
        }
        else if(msg.arg1==2) //验证验证码
        {
            HDLog.Toast(msg.obj.toString());

            //提交服务器注册....
            RegisterUser();
        }

    }

    private void RegisterUser()
    {
        //验证手机号
        String mob=et_mobile.getText().toString();

        String pass=et_password.getText().toString();

        String name=et_nickname.getText().toString();

        //发送消息

        register_req req=new register_req();

        req.tel=mob;
        req.pass=pass;
        req.nickname=name;

        NetManager.SendMsg(req);
    }

    private String GetErrText(int code)
    {
        if(code==207)
        {
            return "验证码错误";
        }
        else
        {
            return "验证错误码:"+code;
        }
    }


}

class reqdata
{
    public String mobilePhoneNumber;
    public String template;
}
class reqdata2
{
    public String mobilePhoneNumber;
}
class resdata
{
    public int code;
    public String error;
}
