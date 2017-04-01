package pf.com.butterfly.module;

import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import com.nostra13.universalimageloader.core.ImageLoader;
import com.nostra13.universalimageloader.core.ImageLoaderConfiguration;

import pf.com.butterfly.MainActivity;
import pf.com.butterfly.ModuleManager;
import pf.com.butterfly.R;
import pf.com.butterfly.component.HtmlTextView;
import pf.com.butterfly.util.HDLog;

/**
 * Created by admin on 2017/3/3.
 */
public class LogView
{
    public static TextView tv=null;
    public static Button btn_close=null;

    public static View father;

    //测试图文混排
    public static void init()
    {
        //布局
        View view= MainActivity.main.findViewById(R.id.layer5);
        //父容器
        father=view.findViewById(R.id.show_log);

        tv=(TextView)view.findViewById(R.id.t_log);
        btn_close=(Button) view.findViewById(R.id.btn_close);
        btn_close.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Hide();
            }
        });

        view.findViewById(R.id.btn_clean).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                HDLog.logs="";
                tv.setText(HDLog.logs);
            }
        });

    }

    public static void Hide()
    {
        father.setVisibility(View.INVISIBLE);
    }

    public static void Show()
    {
        father.setVisibility(View.VISIBLE);

        HDLog.info("----------------------------");

        tv.setText(HDLog.logs);
    }

}
