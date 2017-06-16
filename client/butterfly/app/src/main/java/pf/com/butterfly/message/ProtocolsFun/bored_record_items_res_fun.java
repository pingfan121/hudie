package pf.com.butterfly.message.ProtocolsFun;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.MsgCodeId;
import pf.com.butterfly.message.IMsgCallback;
import pf.com.butterfly.message.Protocols.bored_record_item_add_res;
import pf.com.butterfly.message.Protocols.bored_record_items_res;
import pf.com.butterfly.module.bored.BoredDetail;

public class bored_record_items_res_fun implements IMsgCallback
{
    
      public void MsgCallback(MsgBase msg)
      {
          //  BoredDetail.getInstance().updateAdapter((bored_record_items_res)msg);
      }
}
