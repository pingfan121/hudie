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
		[Id(Name = "id", Strategy = GenerationType.GUID)]
		public string Id{ get; set{changedKeys.Add("Id");}} 

		[Column(Name = "userid")]
		public string Userid{ get; set{changedKeys.Add("Userid");}} 

		[Column(Name = "content")]
		public string Content{ get; set{changedKeys.Add("Content");}} 

		[Column(Name = "time")]
		public DateTime Time{ get; set{changedKeys.Add("Time");}} 

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

