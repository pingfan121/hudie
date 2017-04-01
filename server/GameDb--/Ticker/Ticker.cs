// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading;
// using GameLib.Util;
// 
// namespace GameLib.Ticker
// {
//     public class Ticker
//     {
//         static private LogImplement log = LogFactory.getLogger(typeof(Ticker));
// 
//         public delegate int DefTickerCallback(object[] state, bool expire);
// 
//         private Timer _tmPeriod;
//         private Timer _tmExpire;
//         private DefTickerCallback _callback;
//         private object[] _state;
//         private bool _expired;
//         private int _periodCounter;
// 
//         public bool Expired
//         {
//             get { return _expired; }
//         }
// 
//         public int PeriodCounter
//         {
//             get { return _periodCounter; }
//         }
// 
//         public Ticker(DefTickerCallback callback, object state, long expTime)
//         {
//             _callback = callback;
//             _state = new object[] { state };
//             change(expTime, -1, -1);
//         }
// 
//         public Ticker(DefTickerCallback callback, object[] state, long expTime)
//         {
//             _callback = callback;
//             _state = state;
//             change(expTime, -1, -1);
//         }
// 
//         public Ticker(DefTickerCallback callback, object state, long dueTime, long period)
//         {
//             _callback = callback;
//             _state = new object[] { state };
//             change(-1, dueTime, period);
//         }
// 
//         public Ticker(DefTickerCallback callback, object[] state, long dueTime, long period)
//         {
//             _callback = callback;
//             _state = state;
//             change(-1, dueTime, period);
//         }
// 
//         public Ticker(DefTickerCallback callback, object state, long expTime, long dueTime, long period)
//         {
//             _callback = callback;
//             _state = new object[] { state };
//             change(expTime, dueTime, period);
//         }
// 
//         public Ticker(DefTickerCallback callback, object[] state, long expTime, long dueTime, long period)
//         {
//             _callback = callback;
//             _state = state;
//             change(expTime, dueTime, period);
//         }
// 
//         public bool change(long expTime)
//         {
//             return change(expTime, -1, -1);
//         }
// 
//         public bool change(long dueTime, long period)
//         {
//             return change(-1, dueTime, period);
//         }
// 
//         public bool change(long expTime, long dueTime, long period)
//         {
//             if (_tmExpire == null)
//             {
//                 TimerCallback tcb = TickerReactor.getInstance().onTickExpire;
//                 _tmExpire = new Timer(tcb, this, (long)Timeout.Infinite, (long)Timeout.Infinite);
//             }
//             if (_tmPeriod == null)
//             {
//                 TimerCallback tcb = TickerReactor.getInstance().onTickPeriod;
//                 _tmPeriod = new Timer(tcb, this, (long)Timeout.Infinite, (long)Timeout.Infinite);
//             }
// 
//             bool br = false;
//             br |= _tmExpire.Change(expTime, Timeout.Infinite);
//             br |= _tmPeriod.Change(dueTime, period);
//             if (br == false)
//                 dispose();
//             else
//                 _expired = false;
// 
//             return true;
//         }
// 
//         public void dispose()
//         {
//             if (_tmExpire != null)
//             {
//                 _tmExpire.Dispose();
//                 _tmExpire = null;
//             }
//             if (_tmPeriod != null)
//             {
//                 _tmPeriod.Dispose();
//                 _tmPeriod = null;
//             }
//         }
// 
//         public void expire()
//         {
//             if(_tmExpire != null)
//                 _tmExpire.Change(Timeout.Infinite, Timeout.Infinite);
//             if(_tmPeriod != null)
//                 _tmPeriod.Change(Timeout.Infinite, Timeout.Infinite);
//             if(_callback != null)
//                 _callback(_state, true);
// 
//             _expired = true;
//             _periodCounter = 0;
//         }
// 
//         public int period()
//         {
//             int ir = 0;
//             if (_callback != null)
//             {
//                 ir = _callback(_state, false);
//                 _periodCounter += 1;
//             }
// 
//             return ir;
//         }
//     }
// }
