package pf.com.butterfly.module.login.view;

import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseActivity;
import pf.com.butterfly.message.Protocols.register_req;
import pf.com.butterfly.message.net.NetManager;

/**
 * A login screen that offers login via email/password.
 */
public class RegisterActivity extends AppBaseActivity {


    protected EditText et_mobile;
    protected EditText et_password;
    protected EditText et_nickname;
    protected Button btn_register;

    //初始化视图
    @Override
    protected void initView() {
        super.initView();

        setContentView(R.layout.activity_register);

        et_mobile=(EditText)findViewById(R.id.et_mobile);
        et_password=(EditText)findViewById(R.id.et_password);
        et_nickname=(EditText)findViewById(R.id.et_name);
        btn_register=(Button) findViewById(R.id.btn_register);

        btn_register.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                OnRegisterBtn();
            }
        });


//        ActionBar bar= getSupportActionBar();
//
//        bar.setDisplayHomeAsUpEnabled(true);
//
//        bar.setTitle("注册");


    }

    //登录按钮事件
    private void OnRegisterBtn()
    {
        //验证手机号
        String mob=et_mobile.getText().toString();

        String pass=et_password.getText().toString();

        String name=et_nickname.getText().toString();

        //发送消息

        register_req req=new register_req();

        req.tel=mob;
        req.pass=pass;
        req.nickname=name;

        NetManager.SendMsg(req);

    }

    //左上角的返回键
    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        // TODO Auto-generated method stub
        if(item.getItemId() == android.R.id.home)
        {
            finish();
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}

