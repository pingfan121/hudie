using System.Collections.Generic;using System.Collections;using GameLib.game;using GameServer.Define.EnumNormal;namespace GameDb.Data{	public class TbDataPopularBoss{		/**		* ID		*/		public int Id;		/**		* 条件类型		*/		public int[] ConditionType;		/**		* 计数		*/		public int[] CheckCount;		/**		* 比对ID		*/		public int[] CheckID;		/**		* 物品ID(通用)		*/		public int[] ItemBaseID;		/**		* 物品数量(通用)		*/		public int[] ItemCount;		/**		* 物品ID(男战士)		*/		public int[] ZhanMaleID;		/**		* 物品ID(女战士)		*/		public int[] ZhanFemaleID;		/**		* 物品ID(男法师)		*/		public int[] FaMaleID;		/**		* 物品ID(女法师)		*/		public int[] FaFemaleID;		/**		* 物品ID(男道士)		*/		public int[] DaoMaleID;		/**		* 物品ID(女道士)		*/		public int[] DaoFemaleID;		/**		* 名称		*/		public string Name;		static public Dictionary<int, TbDataPopularBoss> temples=new Dictionary<int,TbDataPopularBoss>();		static public void initdata(Dictionary<int,Hashtable> table){			foreach(Hashtable tb in table.Values){			try{				TbDataPopularBoss tp=new TbDataPopularBoss();				temples[(int)tb["Id"]] = tp;				tp.Id=(int)tb["Id"];				tp.ConditionType=(int[])tb["ConditionType"];				tp.CheckCount=(int[])tb["CheckCount"];				tp.CheckID=(int[])tb["CheckID"];				tp.ItemBaseID=(int[])tb["ItemBaseID"];				tp.ItemCount=(int[])tb["ItemCount"];				tp.ZhanMaleID=(int[])tb["ZhanMaleID"];				tp.ZhanFemaleID=(int[])tb["ZhanFemaleID"];				tp.FaMaleID=(int[])tb["FaMaleID"];				tp.FaFemaleID=(int[])tb["FaFemaleID"];				tp.DaoMaleID=(int[])tb["DaoMaleID"];				tp.DaoFemaleID=(int[])tb["DaoFemaleID"];				tp.Name=(string)tb["Name"];			}catch(System.Exception ee){				System.Console.WriteLine(ee);			}			}		}	static public TbDataPopularBoss select(int id) {		if (temples.ContainsKey(id)) {			return temples[id];		}		return null;	}	}}