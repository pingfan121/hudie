using messages;

namespace messages.Protocols
{
  public class bored_record_item_add_req : MsgBase
  {
      public bored_record_item_add_req()
      {
          CodeId = MsgCodeId.bored_record_item_add_req;
      }
      public string head_id;    //
      public string url;    //
      public int time;    //

	}
}
