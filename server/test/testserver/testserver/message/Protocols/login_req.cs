using messages;

namespace messages.Protocols
{
  public class login_req : MsgBase
  {
      public login_req()
      {
          CodeId = MsgCodeId.login_req;
      }
      public string tel;    ////手机号
      public string pass;    ////密码

	}
}
