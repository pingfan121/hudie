using messages;

namespace messages.Protocols
{
  public class benefit_head_res : MsgBase
  {
      public benefit_head_res()
      {
          CodeId = MsgCodeId.benefit_head_res;
      }
      public info_benefit_head_item[] infos;    //

	}
}
