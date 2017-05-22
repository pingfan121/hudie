using System;
using System.Collections.Generic; 
using System.Text;  
using Easy4net.CustomAttributes; 
namespace GameDb.Logic  
{  
	 [Table(Name = "bored_head_detail")] 
	 public class TbBoredHeadDetail:TbLogic
	 { 
		private string _id;
		[Id(Name = "id", Strategy = GenerationType.GUID)]
		public string Id{ 
			get{ return _id;}
			 set{_id=value;}
		} 

		private string _headid;
		[Column(Name = "headid")]
		public string Headid{ 
			get{ return _headid;}
			 set{if(_headid==value)return;
			_headid=value;
			changedKeys.Add("Headid");}
		} 

		private string _useid;
		[Column(Name = "useid")]
		public string Useid{ 
			get{ return _useid;}
			 set{if(_useid==value)return;
			_useid=value;
			changedKeys.Add("Useid");}
		} 

		private string _record_url;
		[Column(Name = "record_url")]
		public string RecordUrl{ 
			get{ return _record_url;}
			 set{if(_record_url==value)return;
			_record_url=value;
			changedKeys.Add("RecordUrl");}
		} 

		private int _record_len;
		[Column(Name = "record_len")]
		public int RecordLen{ 
			get{ return _record_len;}
			 set{if(_record_len==value)return;
			_record_len=value;
			changedKeys.Add("RecordLen");}
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
         TbBoredHeadDetail t=tblogic as TbBoredHeadDetail;
			Headid=t.Headid;
			Useid=t.Useid;
			RecordUrl=t.RecordUrl;
			RecordLen=t.RecordLen;
			Createtime=t.Createtime;
       }	 } 
}    

