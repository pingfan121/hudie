using System;
using System.Collections.Generic; 
using System.Text;  
using Easy4net.CustomAttributes; 
namespace GameDb.Logic  
{  
	 [Table(Name = "app_user")] 
	 public class TbAppUser:TbLogic
	 { 
		private string _id;
		[Id(Name = "id", Strategy = GenerationType.GUID)]
		public string Id{ 
			get{ return _id;}
			 set{_id=value;}
		} 

		private string _mobile;
		[Column(Name = "mobile")]
		public string Mobile{ 
			get{ return _mobile;}
			 set{if(_mobile==value)return;
			_mobile=value;
			changedKeys.Add("Mobile");}
		} 

		private string _mail;
		[Column(Name = "mail")]
		public string Mail{ 
			get{ return _mail;}
			 set{if(_mail==value)return;
			_mail=value;
			changedKeys.Add("Mail");}
		} 

		private string _pass;
		[Column(Name = "pass")]
		public string Pass{ 
			get{ return _pass;}
			 set{if(_pass==value)return;
			_pass=value;
			changedKeys.Add("Pass");}
		} 

		private string _wx_id;
		[Column(Name = "wx_id")]
		public string WxId{ 
			get{ return _wx_id;}
			 set{if(_wx_id==value)return;
			_wx_id=value;
			changedKeys.Add("WxId");}
		} 

		private string _wb_id;
		[Column(Name = "wb_id")]
		public string WbId{ 
			get{ return _wb_id;}
			 set{if(_wb_id==value)return;
			_wb_id=value;
			changedKeys.Add("WbId");}
		} 

		private string _name;
		[Column(Name = "name")]
		public string Name{ 
			get{ return _name;}
			 set{if(_name==value)return;
			_name=value;
			changedKeys.Add("Name");}
		} 

		private string _head;
		[Column(Name = "head")]
		public string Head{ 
			get{ return _head;}
			 set{if(_head==value)return;
			_head=value;
			changedKeys.Add("Head");}
		} 

		private int _sex;
		[Column(Name = "sex")]
		public int Sex{ 
			get{ return _sex;}
			 set{if(_sex==value)return;
			_sex=value;
			changedKeys.Add("Sex");}
		} 

		private long _createtime;
		[Column(Name = "createtime")]
		public long Createtime{ 
			get{ return _createtime;}
			 set{if(_createtime==value)return;
			_createtime=value;
			changedKeys.Add("Createtime");}
		} 


       override public void copy(TbLogic tblogic) {
         if (tblogic == this)return;
         TbAppUser t=tblogic as TbAppUser;
			Mobile=t.Mobile;
			Mail=t.Mail;
			Pass=t.Pass;
			WxId=t.WxId;
			WbId=t.WbId;
			Name=t.Name;
			Head=t.Head;
			Sex=t.Sex;
			Createtime=t.Createtime;
       }	 } 
}    

