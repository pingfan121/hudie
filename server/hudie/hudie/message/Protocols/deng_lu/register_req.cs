using messages;

namespace messages.Protocols
{
  public class register_req : MsgBase
  {
      public register_req()
      {
          CodeId = MsgCodeId.register_req;
      }
      public string tel;    ////手机号
      public string nickname;    ////昵称
      public string pass;    ////密码

	}
}
