using System;
using System.Collections.Generic; 
using System.Linq;  
using System.Text;  
using Easy4net.CustomAttributes;  
namespace GameDb.Logic  
{  
	 [Table(Name = "bored_head_detail")] 
	 public class TbBoredHeadDetail:TbLogic
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
		public string _headid;
		[Column(Name = "headid")]
		public string Headid{
			get{ return _headid;}
			set
			{
				_headid = value;
				changedKeys.Add("Headid");
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
		public int _record_len;
		[Column(Name = "record_len")]
		public int RecordLen{
			get{ return _record_len;}
			set
			{
				_record_len = value;
				changedKeys.Add("RecordLen");
			}
		}
		public string _record_url;
		[Column(Name = "record_url")]
		public string RecordUrl{
			get{ return _record_url;}
			set
			{
				_record_url = value;
				changedKeys.Add("RecordUrl");
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
		public TbBoredHeadDetail()
		{
			Headid ="";
			Useid ="";
			RecordUrl ="";
		}
		public TbBoredHeadDetail copy()
		{
			TbBoredHeadDetail t = new TbBoredHeadDetail();

			t.Id = Id;
			t.Headid = Headid;
			t.Useid = Useid;
			t.RecordLen = RecordLen;
			t.RecordUrl = RecordUrl;
			t.Createtime = Createtime;
			return t;
		}
	 } 
}    

