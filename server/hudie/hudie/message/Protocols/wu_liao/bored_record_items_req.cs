using messages;

namespace messages.Protocols
{
  public class bored_record_items_req : MsgBase
  {
      public bored_record_items_req()
      {
          CodeId = MsgCodeId.bored_record_items_req;
      }
      public string head_id;    //

	}
}
