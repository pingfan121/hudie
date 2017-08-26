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
		public string _id;
		[Id(Name = "id", Strategy = GenerationType.GUID)]
		public string Id{
			get{ return _id;}
			set
			{
				_id = value;
			}
		}
		public string _useid;
		[Column(Name = "useid")]
		public string Useid{
			get{ return _useid;}
			set
			{
				_useid = value;
				changedKeys.Add("Useid");
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
		public long _createtime;
		[Column(Name = "createtime")]
		public long Createtime{
			get{ return _createtime;}
			set
			{
				_createtime = value;
				changedKeys.Add("Createtime");
			}
		}
		public int _rownum;
		[Column(Name = "rownum")]
		public int Rownum{
			get{ return _rownum;}
			set
			{
				_rownum = value;
				changedKeys.Add("Rownum");
			}
		}
		public int _invalid;
		[Column(Name = "invalid")]
		public int Invalid{
			get{ return _invalid;}
			set
			{
				_invalid = value;
				changedKeys.Add("Invalid");
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
			t.Createtime = Createtime;
			t.Rownum = Rownum;
			t.Invalid = Invalid;
			return t;
		}
	 } 
}    

