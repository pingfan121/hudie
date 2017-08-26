using System;
using System.Collections.Generic; 
using System.Linq;  
using System.Text;  
using Easy4net.CustomAttributes;  
namespace GameDb.Logic  
{  
	 [Table(Name = "benefit_juankuan")] 
	 public class TbBenefitJuankuan:TbLogic
	 { 
		public string _id;
		[Column(Name = "id")]
		public string Id{
			get{ return _id;}
			set
			{
				_id = value;
				changedKeys.Add("Id");
			}
		}
		public string _userid;
		[Column(Name = "userid")]
		public string Userid{
			get{ return _userid;}
			set
			{
				_userid = value;
				changedKeys.Add("Userid");
			}
		}
		public string _itemid;
		[Column(Name = "itemid")]
		public string Itemid{
			get{ return _itemid;}
			set
			{
				_itemid = value;
				changedKeys.Add("Itemid");
			}
		}
		public float _gold;
		[Column(Name = "gold")]
		public float Gold{
			get{ return _gold;}
			set
			{
				_gold = value;
				changedKeys.Add("Gold");
			}
		}
		public DateTime _time;
		[Column(Name = "time")]
		public DateTime Time{
			get{ return _time;}
			set
			{
				_time = value;
				changedKeys.Add("Time");
			}
		}
		public TbBenefitJuankuan()
		{
			Id ="";
			Userid ="";
			Itemid ="";
		}
		public TbBenefitJuankuan copy()
		{
			TbBenefitJuankuan t = new TbBenefitJuankuan();

			t.Id = Id;
			t.Userid = Userid;
			t.Itemid = Itemid;
			t.Gold = Gold;
			t.Time = Time;
			return t;
		}
	 } 
}    

