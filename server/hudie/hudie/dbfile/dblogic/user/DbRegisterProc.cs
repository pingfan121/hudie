using GameDb.Logic;
using GameLib.Database;
using hudie.net;
using messages.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Util;
using hudie.tool;

namespace hudie.sql.proc
{
    class DbRegisterProc :IDb
    {
       
        public override void processReq(IDbConnect connect)
        {

           
            frame.AddRes(this);
        }
        public override void processRes()
        {
          
        }
    }
}
