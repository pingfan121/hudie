using messages;

namespace messages.Protocols
{
  public class bored_head_item_add_res : MsgBase
  {
      public bored_head_item_add_res()
      {
          CodeId = MsgCodeId.bored_head_item_add_res;
      }
      public int state;    //
      public info_bored_head_item info;    //

	}
}
