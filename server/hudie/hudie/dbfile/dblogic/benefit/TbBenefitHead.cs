using System;
using System.Collections.Generic; 
using System.Linq;  
using System.Text;  
using Easy4net.CustomAttributes;  
namespace GameDb.Logic  
{  
	 [Table(Name = "benefit_head")] 
	 public class TbBenefitHead:TbLogic
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
		public DateTime _createtime;
		[Column(Name = "createtime")]
		public DateTime Createtime{
			get{ return _createtime;}
			set
			{
				_createtime = value;
				changedKeys.Add("Createtime");
			}
		}
		public string _name;
		[Column(Name = "name")]
		public string Name{
			get{ return _name;}
			set
			{
				_name = value;
				changedKeys.Add("Name");
			}
		}
		public string _addr;
		[Column(Name = "addr")]
		public string Addr{
			get{ return _addr;}
			set
			{
				_addr = value;
				changedKeys.Add("Addr");
			}
		}
		public int _needmoney;
		[Column(Name = "needmoney")]
		public int Needmoney{
			get{ return _needmoney;}
			set
			{
				_needmoney = value;
				changedKeys.Add("Needmoney");
			}
		}
		public int _nowmoney;
		[Column(Name = "nowmoney")]
		public int Nowmoney{
			get{ return _nowmoney;}
			set
			{
				_nowmoney = value;
				changedKeys.Add("Nowmoney");
			}
		}
		public int _over;
		[Column(Name = "over")]
		public int Over{
			get{ return _over;}
			set
			{
				_over = value;
				changedKeys.Add("Over");
			}
		}
		public string _details;
		[Column(Name = "details")]
		public string Details{
			get{ return _details;}
			set
			{
				_details = value;
				changedKeys.Add("Details");
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
		public string _username;
		[Column(Name = "username")]
		public string Username{
			get{ return _username;}
			set
			{
				_username = value;
				changedKeys.Add("Username");
			}
		}
		public TbBenefitHead()
		{
			Name ="";
			Addr ="";
			Details ="";
			Userid ="";
			Username ="";
		}
		public TbBenefitHead copy()
		{
			TbBenefitHead t = new TbBenefitHead();

			t.Id = Id;
			t.Createtime = Createtime;
			t.Name = Name;
			t.Addr = Addr;
			t.Needmoney = Needmoney;
			t.Nowmoney = Nowmoney;
			t.Over = Over;
			t.Details = Details;
			t.Userid = Userid;
			t.Username = Username;
			return t;
		}
	 } 
}    

