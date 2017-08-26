using System;
using System.Collections.Generic; 
using System.Linq;  
using System.Text;  
using Easy4net.CustomAttributes;  
namespace GameDb.Logic  
{  
	 [Table(Name = "game_2048_rank")] 
	 public class TbGame2048Rank:TbLogic
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
		public string _name;
		[Column(Name = "name")]
		public string Name{
			get{ return _name;}
			set
			{
				_name = value;
				changedKeys.Add("Name");
			}
		}
		public string _four_data;
		[Column(Name = "four_data")]
		public string FourData{
			get{ return _four_data;}
			set
			{
				_four_data = value;
				changedKeys.Add("FourData");
			}
		}
		public string _six_data;
		[Column(Name = "six_data")]
		public string SixData{
			get{ return _six_data;}
			set
			{
				_six_data = value;
				changedKeys.Add("SixData");
			}
		}
		public int _six_max_score;
		[Column(Name = "six_max_score")]
		public int SixMaxScore{
			get{ return _six_max_score;}
			set
			{
				_six_max_score = value;
				changedKeys.Add("SixMaxScore");
			}
		}
		public TbGame2048Rank()
		{
			Name ="";
			FourData ="";
			SixData ="";
		}
		public TbGame2048Rank copy()
		{
			TbGame2048Rank t = new TbGame2048Rank();

			t.Id = Id;
			t.Name = Name;
			t.FourData = FourData;
			t.SixData = SixData;
			t.SixMaxScore = SixMaxScore;
			return t;
		}
	 } 
}    

