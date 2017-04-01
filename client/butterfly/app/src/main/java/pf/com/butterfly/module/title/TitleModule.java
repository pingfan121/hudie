package pf.com.butterfly.module.title;

import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;

import pf.com.butterfly.ModuleManager;
import pf.com.butterfly.R;
import pf.com.butterfly.module.LogView;

/**
 * Created by admin on 2017/3/5.
 */
public class TitleModule
{
    private static TitleModule _instance=null;

    public static TitleModule getInstance()
    {
        if(_instance==null)
        {
            _instance=new TitleModule();
        }

        return _instance ;
    }


    private View view;
    private ImageButton btn_backawd ;//返回按钮
    private ImageButton btn_shuoming;  //说明按钮
    private TextView t_title;  //标题

    private ITitleExplain explain;  //说明按钮的接口




    public void init(View father)
    {
        view= father.findViewById(R.id.module_title);

        btn_backawd=(ImageButton)view.findViewById(R.id.btn_fanhui);
        btn_shuoming=(ImageButton)view.findViewById(R.id.btn_wenhao);
        t_title=(TextView)view.findViewById(R.id.t_title);

        btn_backawd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OnBtnBack();
            }
        });

        btn_shuoming.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OnBtnShuoMing();
            }
        });


    }

    //返回按钮事件
    public void OnBtnBack()
    {
        ModuleManager.Rollback();
    }


    public void OnBtnShuoMing()
    {
//       if(explain!=null)
//       {
//           explain.TitleExplain();
//       }

        LogView.Show();
    }
    //其他事件

    //设置标题
    public void SetTitle(String title)
    {
        t_title.setText(title);
        explain=null;

    //    btn_shuoming.setVisibility(View.INVISIBLE);

        btn_backawd.setImageResource(R.drawable.fanhui);
    }
    public void SetTitle(String title,ITitleExplain explain)
    {
        t_title.setText(title);
        this.explain=explain;

//        if(explain==null)
//        {
//            btn_shuoming.setVisibility(View.INVISIBLE);
//        }
//        else
//        {
//            btn_shuoming.setVisibility(View.VISIBLE);
//        }

        btn_backawd.setImageResource(R.drawable.fanhui);
    }

    public void SetCatalogIcon()
    {
        btn_backawd.setImageResource(R.drawable.sanheng);
    }

}
