using messages;

namespace messages.Protocols
{
  public class login_weixin_res : MsgBase
  {
      public login_weixin_res()
      {
          CodeId = MsgCodeId.login_weixin_res;
      }
      public int state;    //
      public info_user info;    //

	}
}
