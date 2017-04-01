using System.Collections.Generic;using System.Collections;using GameLib.game;using GameServer.Define.EnumNormal;namespace GameDb.Data{	public class TbDataRefineExp{		/**		* ID		*/		public int Id;		/**		* 消耗元宝(第1天)		*/		public int Cost1;		/**		* 获得经验(第1天)		*/		public int Exp1;		/**		* 消耗元宝(第2天)		*/		public int Cost2;		/**		* 获得经验(第2天)		*/		public int Exp2;		/**		* 消耗元宝(第3天)		*/		public int Cost3;		/**		* 获得经验(第3天)		*/		public int Exp3;		static public Dictionary<int, TbDataRefineExp> temples=new Dictionary<int,TbDataRefineExp>();		static public void initdata(Dictionary<int,Hashtable> table){			foreach(Hashtable tb in table.Values){			try{				TbDataRefineExp tp=new TbDataRefineExp();				temples[(int)tb["Id"]] = tp;				tp.Id=(int)tb["Id"];				tp.Cost1=(int)tb["Cost1"];				tp.Exp1=(int)tb["Exp1"];				tp.Cost2=(int)tb["Cost2"];				tp.Exp2=(int)tb["Exp2"];				tp.Cost3=(int)tb["Cost3"];				tp.Exp3=(int)tb["Exp3"];			}catch(System.Exception ee){				System.Console.WriteLine(ee);			}			}		}	static public TbDataRefineExp select(int id) {		if (temples.ContainsKey(id)) {			return temples[id];		}		return null;	}	}}