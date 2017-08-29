using System;
using System.Collections.Generic; 
using System.Linq;  
using System.Text;  
using Easy4net.CustomAttributes;  
namespace GameDb.Logic  
{  
	 [Table(Name = "bored_head")] 
	 public class TbBoredHead:TbLogic
	 { 
		private string _id;
		[Id(Name = "id", Strategy = GenerationType.GUID)]
		public string Id{
			get{ return _id;}
			set
			{
				_id = value;
			}
		}
		private string _useid;
		[Column(Name = "useid")]
		public string Useid{
			get{ return _useid;}
			set
			{
				_useid = value;
				changedKeys.Add("Useid");
			}
		}
		private string _content;
		[Column(Name = "content")]
		public string Content{
			get{ return _content;}
			set
			{
				_content = value;
				changedKeys.Add("Content");
			}
		}
		private long _create_time;
		[Column(Name = "create_time")]
		public long CreateTime{
			get{ return _create_time;}
			set
			{
				_create_time = value;
				changedKeys.Add("CreateTime");
			}
		}
		private int _rownum;
		[Column(Name = "rownum")]
		public int Rownum{
			get{ return _rownum;}
			set
			{
				_rownum = value;
				changedKeys.Add("Rownum");
			}
		}
		private long _invalid_time;
		[Column(Name = "invalid_time")]
		public long InvalidTime{
			get{ return _invalid_time;}
			set
			{
				_invalid_time = value;
				changedKeys.Add("InvalidTime");
			}
		}
		public TbBoredHead()
		{
			Useid ="";
			Content ="";
		}
		public TbBoredHead copy()
		{
			TbBoredHead t = new TbBoredHead();

			t.Id = Id;
			t.Useid = Useid;
			t.Content = Content;
			t.CreateTime = CreateTime;
			t.Rownum = Rownum;
			t.InvalidTime = InvalidTime;
			return t;
		}
	 } 
}    

