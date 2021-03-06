using messages;
using messages.Protocols;
using System.Collections.Generic;

namespace messages
{

  public partial class MsgHandle
  {
       public void init()
      {
           pros.Add(MsgCodeId.login_req,new login_req());
           pros.Add(MsgCodeId.register_req,new register_req());
           pros.Add(MsgCodeId.login_weixin_req,new login_weixin_req());
           pros.Add(MsgCodeId.benefit_head_req,new benefit_head_req());
           pros.Add(MsgCodeId.benefit_detail_req,new benefit_detail_req());
           pros.Add(MsgCodeId.benefit_proof_discuss_req,new benefit_proof_discuss_req());
           pros.Add(MsgCodeId.advise_cteate_req,new advise_cteate_req());
           pros.Add(MsgCodeId.bored_head_items_req,new bored_head_items_req());
           pros.Add(MsgCodeId.bored_record_items_req,new bored_record_items_req());
           pros.Add(MsgCodeId.bored_head_item_add_req,new bored_head_item_add_req());
           pros.Add(MsgCodeId.bored_record_item_add_req,new bored_record_item_add_req());
           profuns.Add(MsgCodeId.login_req,handle_login_req);
           profuns.Add(MsgCodeId.register_req,handle_register_req);
       //    profuns.Add(MsgCodeId.login_weixin_req,handle_login_weixin_req);
           profuns.Add(MsgCodeId.benefit_head_req,handle_benefit_head_req);
           profuns.Add(MsgCodeId.benefit_detail_req,handle_benefit_detail_req);
           profuns.Add(MsgCodeId.benefit_proof_discuss_req,handle_benefit_proof_discuss_req);
           profuns.Add(MsgCodeId.advise_cteate_req,handle_advise_cteate_req);
           profuns.Add(MsgCodeId.bored_head_items_req,handle_bored_head_items_req);
           profuns.Add(MsgCodeId.bored_record_items_req,handle_bored_record_items_req);
           profuns.Add(MsgCodeId.bored_head_item_add_req,handle_bored_head_item_add_req);
           profuns.Add(MsgCodeId.bored_record_item_add_req,handle_bored_record_item_add_req);
      }
  }
}
