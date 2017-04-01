package pf.com.butterfly.message.ProtocolsFun;
import android.widget.Toast;

import pf.com.butterfly.ModuleManager;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.MsgCodeId;
import pf.com.butterfly.message.IMsgCallback;
import pf.com.butterfly.message.Protocols.advise_cteate_res;
import pf.com.butterfly.module.advise.AdviseHead;
import pf.com.butterfly.module.advise.AdviseModule;

public class advise_cteate_res_fun implements IMsgCallback
{
    
      public void MsgCallback(MsgBase msg)
      {
            Toast.makeText(ModuleManager.main,"服务端收到了建议",Toast.LENGTH_SHORT).show();
            AdviseHead.getInstance().CleanText();
      }
}
