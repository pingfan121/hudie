﻿using GameLib.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudie.app
{
    public delegate void sql_back(sql_struct select);
    public class sql_struct
    {
        public Object data1;
        public Object data2;
        public Object data3;

        public IDbCmd cmd;

        public sql_back fun;
    }

}
