using messages;

namespace messages.Protocols
{
  public class info_user : MsgBase
  {
      public info_user()
      {
          CodeId = MsgCodeId.info_user;
      }
      public string name;    //
      public int sex;    //
      public string face;    //

	}
}
