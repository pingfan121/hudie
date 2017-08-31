using System;
using System.Collections.Generic; 
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
			 set{_id=value;}
		} 

		private string _useid;
		[Column(Name = "useid")]
		public string Useid{ 
			get{ return _useid;}
			 set{if(_useid==value)return;
			_useid=value;
			changedKeys.Add("Useid");}
		} 

		private string _content;
		[Column(Name = "content")]
		public string Content{ 
			get{ return _content;}
			 set{if(_content==value)return;
			_content=value;
			changedKeys.Add("Content");}
		} 

		private long _createtime;
		[Column(Name = "createtime")]
		public long Createtime{ 
			get{ return _createtime;}
			 set{if(_createtime==value)return;
			_createtime=value;
			changedKeys.Add("Createtime");}
		} 

		private int _rownum;
		[Column(Name = "rownum")]
		public int Rownum{ 
			get{ return _rownum;}
			 set{if(_rownum==value)return;
			_rownum=value;
			changedKeys.Add("Rownum");}
		} 

		private int _invalid;
		[Column(Name = "invalid")]
		public int Invalid{ 
			get{ return _invalid;}
			 set{if(_invalid==value)return;
			_invalid=value;
			changedKeys.Add("Invalid");}
		} 


       override public void copy(TbLogic tblogic) {
         if (tblogic == this)return;
         TbBoredHead t=tblogic as TbBoredHead;
			Useid=t.Useid;
			Content=t.Content;
			Createtime=t.Createtime;
			Rownum=t.Rownum;
			Invalid=t.Invalid;
       }	 } 
}    

