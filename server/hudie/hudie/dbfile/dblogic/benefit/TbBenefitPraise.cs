using System;
using System.Collections.Generic; 
using System.Linq;  
using System.Text;  
using Easy4net.CustomAttributes;  
namespace GameDb.Logic  
{  
	 [Table(Name = "benefit_praise")] 
	 public class TbBenefitPraise:TbLogic
	 { 
		public string _id;
		[Id(Name = "id", Strategy = GenerationType.GUID)]
		public string Id{
			get{ return _id;}
			set
			{
				_id = value;
			}
		}
		public string _item;
		[Column(Name = "item")]
		public string Item{
			get{ return _item;}
			set
			{
				_item = value;
				changedKeys.Add("Item");
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
		public TbBenefitPraise()
		{
			Item ="";
			Userid ="";
		}
		public TbBenefitPraise copy()
		{
			TbBenefitPraise t = new TbBenefitPraise();

			t.Id = Id;
			t.Item = Item;
			t.Userid = Userid;
			t.Time = Time;
			return t;
		}
	 } 
}    

