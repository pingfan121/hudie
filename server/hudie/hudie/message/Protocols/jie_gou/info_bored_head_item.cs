using messages;

namespace messages.Protocols
{
  public class info_bored_head_item : MsgBase
  {
      public info_bored_head_item()
      {
          CodeId = MsgCodeId.info_bored_head_item;
      }
      public string id;    //
      public string userid;    //
      public string content;    //
      public int rownum;    //

	}
}
