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

		private DateTime _createtime;
		[Column(Name = "createtime")]
		public DateTime Createtime{ 
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
			Createtime=t.Createtime;
       }	 } 
}    

