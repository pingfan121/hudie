using System;
using System.Collections.Generic; 
using System.Linq;  
using System.Text;  
using Easy4net.CustomAttributes;  
namespace GameDb.Logic  
{  
	 [Table(Name = "app_jianyi")] 
	 public class TbAppJianyi:TbLogic
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
		public string _content;
		[Column(Name = "content")]
		public string Content{
			get{ return _content;}
			set
			{
				_content = value;
				changedKeys.Add("Content");
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
		public TbAppJianyi()
		{
			Userid ="";
			Content ="";
		}
		public TbAppJianyi copy()
		{
			TbAppJianyi t = new TbAppJianyi();

			t.Id = Id;
			t.Userid = Userid;
			t.Content = Content;
			t.Time = Time;
			return t;
		}
	 } 
}    

