using messages;

namespace messages.Protocols
{
  public class login_weixin_req : MsgBase
  {
      public login_weixin_req()
      {
          CodeId = MsgCodeId.login_weixin_req;
      }
      public string acc_token;    //

	}
}
