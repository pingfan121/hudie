using messages;

namespace messages.Protocols
{
  public class login_res : MsgBase
  {
      public login_res()
      {
          CodeId = MsgCodeId.login_res;
      }
      public int state;    //
      public string reason;    ////原因
      public string token;    //

	}
}
