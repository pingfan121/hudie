using messages;

namespace messages.Protocols
{
  public class bored_head_items_res : MsgBase
  {
      public bored_head_items_res()
      {
          CodeId = MsgCodeId.bored_head_items_res;
      }
      public info_bored_head_item[] infos;    //

	}
}
