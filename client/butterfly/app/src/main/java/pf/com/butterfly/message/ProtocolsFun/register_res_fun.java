package pf.com.butterfly.message.ProtocolsFun;
import android.content.Intent;
import android.widget.Toast;

import pf.com.butterfly.ModuleManager;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.IMsgCallback;
import pf.com.butterfly.message.Protocols.register_res;
import pf.com.butterfly.module.login.LoginModule;

public class register_res_fun implements IMsgCallback
{
    
      public void MsgCallback(MsgBase msg)
      {
            //这是在主线程里面了
            register_res res=(register_res)msg;

            if(res.state==0)
            {
                  //注册成功
                  Toast.makeText(ModuleManager.main,"哈哈哈",Toast.LENGTH_SHORT).show();

                  //关闭登录模块
                  ModuleManager.CloseModule(LoginModule.class.getName());

            }
            else
            {
                  Toast.makeText(ModuleManager.main,res.reason,Toast.LENGTH_SHORT).show();
            }


      }
}
