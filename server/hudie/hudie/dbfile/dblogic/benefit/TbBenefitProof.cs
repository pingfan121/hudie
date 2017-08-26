using System;
using System.Collections.Generic; 
using System.Linq;  
using System.Text;  
using Easy4net.CustomAttributes;  
namespace GameDb.Logic  
{  
	 [Table(Name = "benefit_proof")] 
	 public class TbBenefitProof:TbLogic
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
		public string _issueid;
		[Column(Name = "issueid")]
		public string Issueid{
			get{ return _issueid;}
			set
			{
				_issueid = value;
				changedKeys.Add("Issueid");
			}
		}
		public string _issuename;
		[Column(Name = "issuename")]
		public string Issuename{
			get{ return _issuename;}
			set
			{
				_issuename = value;
				changedKeys.Add("Issuename");
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
		public int _praise;
		[Column(Name = "praise")]
		public int Praise{
			get{ return _praise;}
			set
			{
				_praise = value;
				changedKeys.Add("Praise");
			}
		}
		public int _discuss;
		[Column(Name = "discuss")]
		public int Discuss{
			get{ return _discuss;}
			set
			{
				_discuss = value;
				changedKeys.Add("Discuss");
			}
		}
		public TbBenefitProof()
		{
			Issueid ="";
			Issuename ="";
			Content ="";
		}
		public TbBenefitProof copy()
		{
			TbBenefitProof t = new TbBenefitProof();

			t.Id = Id;
			t.Issueid = Issueid;
			t.Issuename = Issuename;
			t.Content = Content;
			t.Praise = Praise;
			t.Discuss = Discuss;
			return t;
		}
	 } 
}    

