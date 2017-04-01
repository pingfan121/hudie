using System;
using System.Collections.Generic; 
using System.Text;  
using Easy4net.CustomAttributes; 
namespace GameDb.Logic  
{  
	 [Table(Name = "benefit_discuss")] 
	 public class TbBenefitDiscuss:TbLogic
	 { 
		private string _id;
		[Id(Name = "id", Strategy = GenerationType.GUID)]
		public string Id{ 
			get{ return _id;}
			 set{_id=value;}
		} 

		private string _itemid;
		[Column(Name = "itemid")]
		public string Itemid{ 
			get{ return _itemid;}
			 set{if(_itemid==value)return;
			_itemid=value;
			changedKeys.Add("Itemid");}
		} 

		private string _userid;
		[Column(Name = "userid")]
		public string Userid{ 
			get{ return _userid;}
			 set{if(_userid==value)return;
			_userid=value;
			changedKeys.Add("Userid");}
		} 

		private string _content;
		[Column(Name = "content")]
		public string Content{ 
			get{ return _content;}
			 set{if(_content==value)return;
			_content=value;
			changedKeys.Add("Content");}
		} 

		private DateTime _time;
		[Column(Name = "time")]
		public DateTime Time{ 
			get{ return _time;}
			 set{if(_time==value)return;
			_time=value;
			changedKeys.Add("Time");}
		} 


       override public void copy(TbLogic tblogic) {
         if (tblogic == this)return;
         TbBenefitDiscuss t=tblogic as TbBenefitDiscuss;
			Itemid=t.Itemid;
			Userid=t.Userid;
			Content=t.Content;
			Time=t.Time;
       }	 } 
}    

