using System.Collections.Generic;using System.Collections;using GameLib.game;using GameServer.Define.EnumNormal;namespace GameDb.Data{	public class TbDataTotemRecycle{		/**		* id		*/		public int Id;		/**		* 回收属性ID		*/		public int BaseID;		/**		* 回收属性值		*/		public int BaseNum;		static public Dictionary<int, TbDataTotemRecycle> temples=new Dictionary<int,TbDataTotemRecycle>();		static public void initdata(Dictionary<int,Hashtable> table){			foreach(Hashtable tb in table.Values){			try{				TbDataTotemRecycle tp=new TbDataTotemRecycle();				temples[(int)tb["Id"]] = tp;				tp.Id=(int)tb["Id"];				tp.BaseID=(int)tb["BaseID"];				tp.BaseNum=(int)tb["BaseNum"];			}catch(System.Exception ee){				System.Console.WriteLine(ee);			}			}		}	static public TbDataTotemRecycle select(int id) {		if (temples.ContainsKey(id)) {			return temples[id];		}		return null;	}	}}