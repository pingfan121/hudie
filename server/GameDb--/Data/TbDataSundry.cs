using System.Collections.Generic;using System.Collections;using GameLib.game;using GameServer.Define.EnumNormal;namespace GameDb.Data{	public class TbDataSundry{		/**		* ID		*/		public int Id;		/**		* 数值		*/		public int Num;		/**		* 说明		*/		public string Desc;		static public Dictionary<int, TbDataSundry> temples=new Dictionary<int,TbDataSundry>();		static public void initdata(Dictionary<int,Hashtable> table){			foreach(Hashtable tb in table.Values){			try{				TbDataSundry tp=new TbDataSundry();				temples[(int)tb["Id"]] = tp;				tp.Id=(int)tb["Id"];				tp.Num=(int)tb["Num"];				tp.Desc=(string)tb["Desc"];			}catch(System.Exception ee){				System.Console.WriteLine(ee);			}			}		}	static public TbDataSundry select(int id) {		if (temples.ContainsKey(id)) {			return temples[id];		}		return null;	}	}}