using System.Collections;
using System.Collections.Generic;
using System;
using messages;
using System.Net;
using hudie;


public class MsgBase
{
    public MsgCodeId CodeId;//可序列化的类的id

}

public class BackMsg
{
    public int state;   //处理状态
    public String reason;  //处理原因
    public int msgid;
    public Object msg;
}

