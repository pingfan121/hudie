using messages;

namespace messages.Protocols
{
  public class bored_record_items_res : MsgBase
  {
      public bored_record_items_res()
      {
          CodeId = MsgCodeId.bored_record_items_res;
      }
      public info_bored_record_item[] infos;    //

	}
}
