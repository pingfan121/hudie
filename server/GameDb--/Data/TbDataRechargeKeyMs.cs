using System.Collections.Generic;using System.Collections;using GameLib.game;using GameServer.Define.EnumNormal;namespace GameDb.Data{	public class TbDataRechargeKeyMs{		/**		* ID		*/		public int Id;		/**		* 所需充值数		*/		public int Money;		/**		* 物品ID(通用)		*/		public int[] ItemBaseID;		/**		* 物品数量(通用)		*/		public int[] ItemCount;		/**		* 物品ID(男战士)		*/		public int[] ZhanMaleID;		/**		* 物品ID(女战士)		*/		public int[] ZhanFemaleID;		/**		* 物品ID(男法师)		*/		public int[] FaMaleID;		/**		* 物品ID(女法师)		*/		public int[] FaFemaleID;		/**		* 物品ID(男道士)		*/		public int[] DaoMaleID;		/**		* 物品ID(女道士)		*/		public int[] DaoFemaleID;		static public Dictionary<int, TbDataRechargeKeyMs> temples=new Dictionary<int,TbDataRechargeKeyMs>();		static public void initdata(Dictionary<int,Hashtable> table){			foreach(Hashtable tb in table.Values){			try{				TbDataRechargeKeyMs tp=new TbDataRechargeKeyMs();				temples[(int)tb["Id"]] = tp;				tp.Id=(int)tb["Id"];				tp.Money=(int)tb["Money"];				tp.ItemBaseID=(int[])tb["ItemBaseID"];				tp.ItemCount=(int[])tb["ItemCount"];				tp.ZhanMaleID=(int[])tb["ZhanMaleID"];				tp.ZhanFemaleID=(int[])tb["ZhanFemaleID"];				tp.FaMaleID=(int[])tb["FaMaleID"];				tp.FaFemaleID=(int[])tb["FaFemaleID"];				tp.DaoMaleID=(int[])tb["DaoMaleID"];				tp.DaoFemaleID=(int[])tb["DaoFemaleID"];			}catch(System.Exception ee){				System.Console.WriteLine(ee);			}			}		}	static public TbDataRechargeKeyMs select(int id) {		if (temples.ContainsKey(id)) {			return temples[id];		}		return null;	}	}}