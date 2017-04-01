// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading;
// using GameLib.Util;
// using GameLib.Event;
// using GameServer.Define.EnumServer;
// 
// namespace GameLib.Ticker
// {
//     public class TickerEvent : IEventHandle
//     {
//         private EnumEventType _eventId;
// 
//         private Object _state;
// 
//         public EnumEventType EventType 
//         { 
// 
//             get { return _eventId; }
//             set { _eventId = value; }
//         }
// 
//         public Object State
//         {
//             get { return _state; }
//             set { _state = value; }
//         }
// 
//         public TickerEvent(EnumEventType eventId, Object state)
//         {
//             _eventId = eventId;
//             _state = state;
//         }
//     }
// 
//     public class TickerReactor : IEventListener
//     {
//         static private LogImplement log = LogFactory.getLogger(typeof(TickerReactor));
// 
//         static private TickerReactor _instance;
//         static public TickerReactor getInstance()
//         {
//             if (_instance == null)
//                 _instance = new TickerReactor();
//             return _instance;
//         }
// 
//         private HashSet<EnumEventType> _listenEvent;
// 
//         public HashSet<EnumEventType> ListenEvent
//         {
//             get { return _listenEvent; }
//             set { _listenEvent = value; }
//         }
// 
//         public TickerReactor()
//         {
//             _listenEvent = new HashSet<EnumEventType>();
//             EventReactor.getInstance().registerEvent(EnumEventType.tiker_expire, this);
//             EventReactor.getInstance().registerEvent(EnumEventType.tiker_period,this);
//         }
//         public int onEventHandler(IEventHandle eventHd)
//         {
//             TickerEvent te = eventHd as TickerEvent;
//             if (te == null)
//                 return -1;
// 
//             Ticker tk = te.State as Ticker;
//             if (tk == null)
//                 return -1;
// 
//             if (eventHd.EventType == EnumEventType.tiker_expire)
//             {
//                 tk.expire();
//                 tk.dispose();
//             }
//             else if (eventHd.EventType == EnumEventType.tiker_period)
//             {
//                 int ir = tk.period();
//                 if (ir != 0)
//                     tk.dispose();
//             }
// 
//             return 0;
//         }
// 
//         public void onTickExpire(object state)
//         {
//             Ticker tk = state as Ticker;
//             if (tk == null)
//                 return;
// 
//             TickerEvent te = new TickerEvent(EnumEventType.tiker_expire, state);
//             EventReactor.getInstance().dispatchEvent(te);
//         }
// 
//         public void onTickPeriod(object state)
//         {
//             Ticker tk = state as Ticker;
//             if (tk == null)
//                 return;
// 
//             TickerEvent te = new TickerEvent(EnumEventType.tiker_period, state);
//             EventReactor.getInstance().dispatchEvent(te);
//         }
// 
//     }
// }
