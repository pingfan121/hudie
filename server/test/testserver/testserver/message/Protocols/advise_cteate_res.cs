using messages;

namespace messages.Protocols
{
  public class advise_cteate_res : MsgBase
  {
      public advise_cteate_res()
      {
          CodeId = MsgCodeId.advise_cteate_res;
      }
      public int state;    //

	}
}
