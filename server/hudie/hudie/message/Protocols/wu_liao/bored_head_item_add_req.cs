using messages;

namespace messages.Protocols
{
  public class bored_head_item_add_req : MsgBase
  {
      public bored_head_item_add_req()
      {
          CodeId = MsgCodeId.bored_head_item_add_req;
      }
      public string content;    //

	}
}
