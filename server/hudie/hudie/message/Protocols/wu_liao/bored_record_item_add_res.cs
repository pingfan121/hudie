using messages;

namespace messages.Protocols
{
  public class bored_record_item_add_res : MsgBase
  {
      public bored_record_item_add_res()
      {
          CodeId = MsgCodeId.bored_record_item_add_res;
      }
      public int state;    //
      public info_bored_record_item info;    //

	}
}
