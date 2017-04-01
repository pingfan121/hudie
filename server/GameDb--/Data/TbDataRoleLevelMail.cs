using System.Collections.Generic;using System.Collections;using GameLib.game;using GameServer.Define.EnumNormal;namespace GameDb.Data{	public class TbDataRoleLevelMail{		/**		* 功能开启表表ID		*/		public int Id;		/**		* 邮件标题		*/		public string Title;		/**		* 物品奖励ID		*/		public int[] ItemID;		/**		* 物品奖励数量		*/		public int[] ItemCount;		/**		* 物品奖励绑定状态		*/		public int[] BindType;		/**		* 邮件内容		*/		public string Content;		static public Dictionary<int, TbDataRoleLevelMail> temples=new Dictionary<int,TbDataRoleLevelMail>();		static public void initdata(Dictionary<int,Hashtable> table){			foreach(Hashtable tb in table.Values){			try{				TbDataRoleLevelMail tp=new TbDataRoleLevelMail();				temples[(int)tb["Id"]] = tp;				tp.Id=(int)tb["Id"];				tp.Title=(string)tb["Title"];				tp.ItemID=(int[])tb["ItemID"];				tp.ItemCount=(int[])tb["ItemCount"];				tp.BindType=(int[])tb["BindType"];				tp.Content=(string)tb["Content"];			}catch(System.Exception ee){				System.Console.WriteLine(ee);			}			}		}	static public TbDataRoleLevelMail select(int id) {		if (temples.ContainsKey(id)) {			return temples[id];		}		return null;	}	}}