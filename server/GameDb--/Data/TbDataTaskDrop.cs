using System.Collections.Generic;using System.Collections;using GameLib.game;using GameServer.Define.EnumNormal;namespace GameDb.Data{	public class TbDataTaskDrop{		/**		* ID		*/		public int Id;		/**		* 任务ID		*/		public int TaskID;		/**		* 怪物ID		*/		public int UnitID;		/**		* 获得物品ID		*/		public int ItemID;		/**		* 掉落概率		*/		public int Rate;		static public Dictionary<int, TbDataTaskDrop> temples=new Dictionary<int,TbDataTaskDrop>();		static public void initdata(Dictionary<int,Hashtable> table){			foreach(Hashtable tb in table.Values){			try{				TbDataTaskDrop tp=new TbDataTaskDrop();				temples[(int)tb["Id"]] = tp;				tp.Id=(int)tb["Id"];				tp.TaskID=(int)tb["TaskID"];				tp.UnitID=(int)tb["UnitID"];				tp.ItemID=(int)tb["ItemID"];				tp.Rate=(int)tb["Rate"];			}catch(System.Exception ee){				System.Console.WriteLine(ee);			}			}		}	static public TbDataTaskDrop select(int id) {		if (temples.ContainsKey(id)) {			return temples[id];		}		return null;	}	}}