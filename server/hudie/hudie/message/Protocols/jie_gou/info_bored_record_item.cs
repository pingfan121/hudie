using messages;

namespace messages.Protocols
{
  public class info_bored_record_item : MsgBase
  {
      public info_bored_record_item()
      {
          CodeId = MsgCodeId.info_bored_record_item;
      }
      public string id;    //
      public string headid;    //
      public string userid;    //
      public string recordurl;    //
      public int recordlength;    //

	}
}
