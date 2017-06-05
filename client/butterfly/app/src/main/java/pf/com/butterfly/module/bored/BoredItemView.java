package pf.com.butterfly.module.bored;

import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import pf.com.butterfly.R;
import pf.com.butterfly.adapter.AdapterItemData;
import pf.com.butterfly.adapter.AdapterItemControl;
import pf.com.butterfly.component.ComQiPao_Text;

/**
 * Created by admin on 2017/5/20.
 */

public class BoredItemView extends AdapterItemControl
{

    public ImageView iv_icon;
    public TextView tv_name;
    public TextView tv_rownum;
    public TextView tv_text;

    public ComQiPao_Text com_qipao;


    private View view;
    @Override
    public void init(View view)
    {
        this.view=view;

        iv_icon=(ImageView)view.findViewById(R.id.iv_face);

        tv_name=(TextView)view.findViewById(R.id.tv_name);
        tv_rownum=(TextView)view.findViewById(R.id.tv_rownum);

        com_qipao=(ComQiPao_Text)view.findViewById(R.id.com_qipao);

//
//        //按下
//        ly_qipao.setOnTouchListener(new View.OnTouchListener()
//        {
//            @Override
//            public boolean onTouch(View view, MotionEvent motionEvent)
//            {
//                //return false;
//                return OnViewTouch(view, motionEvent);
//            }
//        });
    }

    @Override
    public void setData(AdapterItemData obj)
    {
        data=obj;

        BoredHeadItemData itemdata=(BoredHeadItemData)obj;

        tv_name.setText(itemdata.name);
        tv_rownum.setText("跟帖:"+itemdata.num);

        com_qipao.setText(itemdata.text);
        com_qipao.setBackground(false);

    }

//    public static void setBackground(BoredItemView control , boolean flag)
//    {
//        if(control==null)
//        {
//            return;
//        }
//
//        if(control.data==null)
//        {
//            return ;
//        }
//
//        ((BoredHeadItemData)control.data).downflag=flag;
//
//
//        if(flag==false)
//        {
//            control.iv_jiao.setImageResource(R.drawable.qipao1_1);
//            control.tv_text.setBackgroundResource(R.drawable.qipao1_2);
//        }
//        else
//        {
//            control.iv_jiao.setImageResource(R.drawable.qipao2_1);
//            control.tv_text.setBackgroundResource(R.drawable.qipao2_2);
//        }
//    }



//    private static boolean OnViewTouch(View view, MotionEvent event)
//    {
//        int action = event.getAction();
////        int x = (int) event.getX();
////        int y = (int) event.getY();
//        HDLog.error("输出事件类型:"+action);
//        switch (action)
//        {
//            case MotionEvent.ACTION_DOWN:
//            {
//                setBackground((BoredItemView)view.getTag(),true);
//
//                break;
//            }
//            case MotionEvent.ACTION_CANCEL:
//            case MotionEvent.ACTION_UP:
//            {
//                setBackground((BoredItemView)view.getTag(),false);
//                break;
//            }
//            default:
//                break;
//        }
//        return false;
//    }
}

