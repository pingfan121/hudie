using System;
using System.Collections.Generic; 
using System.Linq;  
using System.Text;  
using Easy4net.CustomAttributes;  
namespace GameDb.Logic  
{  
	 [Table(Name = "app_login_log")] 
	 public class TbAppLoginLog:TbLogic
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
		public string _user_id;
		[Column(Name = "user_id")]
		public string UserId{
			get{ return _user_id;}
			set
			{
				_user_id = value;
				changedKeys.Add("UserId");
			}
		}
		public string _ip;
		[Column(Name = "ip")]
		public string Ip{
			get{ return _ip;}
			set
			{
				_ip = value;
				changedKeys.Add("Ip");
			}
		}
		public int _login_time;
		[Column(Name = "login_time")]
		public int LoginTime{
			get{ return _login_time;}
			set
			{
				_login_time = value;
				changedKeys.Add("LoginTime");
			}
		}
		public TbAppLoginLog()
		{
			UserId ="";
			Ip ="";
		}
		public TbAppLoginLog copy()
		{
			TbAppLoginLog t = new TbAppLoginLog();

			t.Id = Id;
			t.UserId = UserId;
			t.Ip = Ip;
			t.LoginTime = LoginTime;
			return t;
		}
	 } 
}    

