using messages;

namespace messages.Protocols
{
  public class info_benefit_head_item : MsgBase
  {
      public info_benefit_head_item()
      {
          CodeId = MsgCodeId.info_benefit_head_item;
      }
      public string itemid;    ////主题的id
      public string name;    ////被救助人的名字
      public string addr;    ////被救助人所在的地址
      public int needmoney;    //所需要救助的金额
      public int nowmoney;    ////现在一斤募集的金额

	}
}
