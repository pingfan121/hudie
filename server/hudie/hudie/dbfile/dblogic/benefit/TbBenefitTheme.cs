using System;
using System.Collections.Generic; 
using System.Text;  
using Easy4net.CustomAttributes; 
namespace GameDb.Logic  
{  
	 [Table(Name = "benefit_theme")] 
	 public class TbBenefitTheme:TbLogic
	 { 
		private string _id;
		[Id(Name = "id", Strategy = GenerationType.GUID)]
		public string Id{ 
			get{ return _id;}
			 set{_id=value;}
		} 

		private DateTime _createtime;
		[Column(Name = "createtime")]
		public DateTime Createtime{ 
			get{ return _createtime;}
			 set{if(_createtime==value)return;
			_createtime=value;
			changedKeys.Add("Createtime");}
		} 

		private string _name;
		[Column(Name = "name")]
		public string Name{ 
			get{ return _name;}
			 set{if(_name==value)return;
			_name=value;
			changedKeys.Add("Name");}
		} 

		private string _addr;
		[Column(Name = "addr")]
		public string Addr{ 
			get{ return _addr;}
			 set{if(_addr==value)return;
			_addr=value;
			changedKeys.Add("Addr");}
		} 

		private int _needmoney;
		[Column(Name = "needmoney")]
		public int Needmoney{ 
			get{ return _needmoney;}
			 set{if(_needmoney==value)return;
			_needmoney=value;
			changedKeys.Add("Needmoney");}
		} 

		private int _nowmoney;
		[Column(Name = "nowmoney")]
		public int Nowmoney{ 
			get{ return _nowmoney;}
			 set{if(_nowmoney==value)return;
			_nowmoney=value;
			changedKeys.Add("Nowmoney");}
		} 

		private int _over;
		[Column(Name = "over")]
		public int Over{ 
			get{ return _over;}
			 set{if(_over==value)return;
			_over=value;
			changedKeys.Add("Over");}
		} 

		private string _details;
		[Column(Name = "details")]
		public string Details{ 
			get{ return _details;}
			 set{if(_details==value)return;
			_details=value;
			changedKeys.Add("Details");}
		} 

		private string _issueid;
		[Column(Name = "issueid")]
		public string Issueid{ 
			get{ return _issueid;}
			 set{if(_issueid==value)return;
			_issueid=value;
			changedKeys.Add("Issueid");}
		} 


       override public void copy(TbLogic tblogic) {
         if (tblogic == this)return;
         TbBenefitTheme t=tblogic as TbBenefitTheme;
			Createtime=t.Createtime;
			Name=t.Name;
			Addr=t.Addr;
			Needmoney=t.Needmoney;
			Nowmoney=t.Nowmoney;
			Over=t.Over;
			Details=t.Details;
			Issueid=t.Issueid;
       }	 } 
}    

