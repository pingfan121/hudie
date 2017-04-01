using System;
using System.Collections.Generic; 
using System.Text;  
using Easy4net.CustomAttributes; 
namespace GameDb.Logic  
{  
	 [Table(Name = "benefit_juankuan")] 
	 public class TbBenefitJuankuan:TbLogic
	 { 
		private string _id;
		[Column(Name = "id")]
		public string Id{ 
			get{ return _id;}
			 set{if(_id==value)return;
			_id=value;
			changedKeys.Add("Id");}
		} 

		private string _userid;
		[Column(Name = "userid")]
		public string Userid{ 
			get{ return _userid;}
			 set{if(_userid==value)return;
			_userid=value;
			changedKeys.Add("Userid");}
		} 

		private string _itemid;
		[Column(Name = "itemid")]
		public string Itemid{ 
			get{ return _itemid;}
			 set{if(_itemid==value)return;
			_itemid=value;
			changedKeys.Add("Itemid");}
		} 

		private float _gold;
		[Column(Name = "gold")]
		public float Gold{ 
			get{ return _gold;}
			 set{if(_gold==value)return;
			_gold=value;
			changedKeys.Add("Gold");}
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
         TbBenefitJuankuan t=tblogic as TbBenefitJuankuan;
			Id=t.Id;
			Userid=t.Userid;
			Itemid=t.Itemid;
			Gold=t.Gold;
			Time=t.Time;
       }	 } 
}    

