using System.Collections.Generic;using System.Collections;using GameLib.game;using GameServer.Define.EnumNormal;namespace GameDb.Data{	public class TbDataPrivilege{		/**		* id		*/		public int Id;		/**		* 价格		*/		public int Price;		/**		* 持续天数		*/		public int Day;		/**		* 		*/		public int ItemID1;		/**		* 领取令牌		*/		public int ItemNum1;		/**		* 		*/		public int IsBind1;		/**		* 		*/		public int ItemID2;		/**		* 领取斧子		*/		public int ItemNum2;		/**		* 		*/		public int IsBind2;		/**		* 增加副本经验比例		*/		public int AddExpPrc;		/**		* 随身仓库次数		*/		public int UseWarehouse;		/**		* 随身回收次数		*/		public int UseRecovery;		/**		* 角色死亡背包装备几率降低		*/		public int Show1;		/**		* 杀怪爆率提高		*/		public int Show2;		/**		* 提高强化成功概率		*/		public int Show3;		/**		* 商城ID		*/		public int ShopID;		static public Dictionary<int, TbDataPrivilege> temples=new Dictionary<int,TbDataPrivilege>();		static public void initdata(Dictionary<int,Hashtable> table){			foreach(Hashtable tb in table.Values){			try{				TbDataPrivilege tp=new TbDataPrivilege();				temples[(int)tb["Id"]] = tp;				tp.Id=(int)tb["Id"];				tp.Price=(int)tb["Price"];				tp.Day=(int)tb["Day"];				tp.ItemID1=(int)tb["ItemID1"];				tp.ItemNum1=(int)tb["ItemNum1"];				tp.IsBind1=(int)tb["IsBind1"];				tp.ItemID2=(int)tb["ItemID2"];				tp.ItemNum2=(int)tb["ItemNum2"];				tp.IsBind2=(int)tb["IsBind2"];				tp.AddExpPrc=(int)tb["AddExpPrc"];				tp.UseWarehouse=(int)tb["UseWarehouse"];				tp.UseRecovery=(int)tb["UseRecovery"];				tp.Show1=(int)tb["Show1"];				tp.Show2=(int)tb["Show2"];				tp.Show3=(int)tb["Show3"];				tp.ShopID=(int)tb["ShopID"];			}catch(System.Exception ee){				System.Console.WriteLine(ee);			}			}		}	static public TbDataPrivilege select(int id) {		if (temples.ContainsKey(id)) {			return temples[id];		}		return null;	}	}}