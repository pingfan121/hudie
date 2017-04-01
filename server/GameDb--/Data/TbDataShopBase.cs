using System.Collections.Generic;using System.Collections;using GameLib.game;using GameServer.Define.EnumNormal;namespace GameDb.Data{	public class TbDataShopBase{		/**		* ID		*/		public int Id;		/**		* 商店类别		*/		public int Type;		/**		* 商店ID		*/		public int ShopID;		/**		* 物品ID		*/		public int ItembaseID;		/**		* 物品数目		*/		public int ItemNum;		/**		* 需要货币		*/		public int MoneyKind;		/**		* 货币数目		*/		public int Money;		/**		* 绑定状态		*/		public int IsBindKind;		/**		* 每日最大购买数量		*/		public int MaxCount;		static public Dictionary<int, TbDataShopBase> temples=new Dictionary<int,TbDataShopBase>();		static public void initdata(Dictionary<int,Hashtable> table){			foreach(Hashtable tb in table.Values){			try{				TbDataShopBase tp=new TbDataShopBase();				temples[(int)tb["Id"]] = tp;				tp.Id=(int)tb["Id"];				tp.Type=(int)tb["Type"];				tp.ShopID=(int)tb["ShopID"];				tp.ItembaseID=(int)tb["ItembaseID"];				tp.ItemNum=(int)tb["ItemNum"];				tp.MoneyKind=(int)tb["MoneyKind"];				tp.Money=(int)tb["Money"];				tp.IsBindKind=(int)tb["IsBindKind"];				tp.MaxCount=(int)tb["MaxCount"];			}catch(System.Exception ee){				System.Console.WriteLine(ee);			}			}		}	static public TbDataShopBase select(int id) {		if (temples.ContainsKey(id)) {			return temples[id];		}		return null;	}	}}