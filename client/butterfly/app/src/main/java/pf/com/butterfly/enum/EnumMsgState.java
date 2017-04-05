  public enum EnumMsgState
  {
      ok = 0, //没有错误
      error = 1, //通用错误
      sign_err = 100, //签名错误(100-200)属于通信错误
      pro_analysis_err = 101, //协议解析错误
      token_past = 200, //token过期了
      err_shuoming = 1000, //1000之后为协议处理错误
      reg_mob_exist = 1001, //手机号已经存在
      reg_mob_format_err = 1002, //手机号格式不正确
      login_password_err = 1003, //密码错误
      login_mob_not_reg = 1004, //手机号没有注册
  }
}
