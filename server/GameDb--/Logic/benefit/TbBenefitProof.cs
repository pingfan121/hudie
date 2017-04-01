using System;
using System.Collections.Generic; 
using System.Text;  
using Easy4net.CustomAttributes; 
namespace GameDb.Logic  
{  
	 [Table(Name = "benefit_proof")] 
	 public class TbBenefitProof:TbLogic
	 { 
		private string _id;
		[Id(Name = "id", Strategy = GenerationType.GUID)]
		public string Id{ 
			get{ return _id;}
			 set{_id=value;}
		} 

		private string _issue;
		[Column(Name = "issue")]
		public string Issue{ 
			get{ return _issue;}
			 set{if(_issue==value)return;
			_issue=value;
			changedKeys.Add("Issue");}
		} 

		private string _content;
		[Column(Name = "content")]
		public string Content{ 
			get{ return _content;}
			 set{if(_content==value)return;
			_content=value;
			changedKeys.Add("Content");}
		} 

		private int _praise;
		[Column(Name = "praise")]
		public int Praise{ 
			get{ return _praise;}
			 set{if(_praise==value)return;
			_praise=value;
			changedKeys.Add("Praise");}
		} 

		private string _discuss;
		[Column(Name = "discuss")]
		public string Discuss{ 
			get{ return _discuss;}
			 set{if(_discuss==value)return;
			_discuss=value;
			changedKeys.Add("Discuss");}
		} 


       override public void copy(TbLogic tblogic) {
         if (tblogic == this)return;
         TbBenefitProof t=tblogic as TbBenefitProof;
			Issue=t.Issue;
			Content=t.Content;
			Praise=t.Praise;
			Discuss=t.Discuss;
       }	 } 
}    

