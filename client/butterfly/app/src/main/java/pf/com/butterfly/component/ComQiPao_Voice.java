package pf.com.butterfly.component;

import android.content.Context;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import pf.com.butterfly.R;

/**
 * Created by admin on 2017/5/25.
 */

public class ComQiPao_Voice extends LinearLayout
{


    public ComQiPao_Voice(Context context, AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        init(context);
    }

    public ComQiPao_Voice(Context context, AttributeSet attrs) {
        super(context, attrs);
        init(context);
    }

    public ComQiPao_Voice(Context context) {
        super(context);
        init(context);
    }

    private Context context;
    private ImageView choose;
    private EditText et;
    private int width;

    private View view;
    private ImageView iv_jiao;
    private TextView tv_text;

    private void init(Context context) {
        this.context = context;

        LayoutInflater inflater= LayoutInflater.from(context);

        view= inflater.inflate(R.layout.com_qipao_text,null);

        this.addView(view);

        tv_text=(TextView)view.findViewById(R.id.tv_text);
        iv_jiao=(ImageView)view.findViewById(R.id.iv_jiao);

    }

    public void setText(String text)
    {
        tv_text.setText(text);
    }

    @Override
    public boolean onTouchEvent(MotionEvent event)
    {
        int action = event.getAction();

        switch (action)
        {
            case MotionEvent.ACTION_DOWN:
            {
                setBackground(true);

                break;
            }
            case MotionEvent.ACTION_CANCEL:
            case MotionEvent.ACTION_UP:
            {
                setBackground(false);
                break;
            }
            default:
                break;
        }

        return true;
    }

    public void setBackground(boolean flag)
    {
        if(flag==false)
        {
            iv_jiao.setImageResource(R.drawable.qipao1_1);
            tv_text.setBackgroundResource(R.drawable.qipao1_2);
        }
        else
        {
            iv_jiao.setImageResource(R.drawable.qipao2_1);
            tv_text.setBackgroundResource(R.drawable.qipao2_2);
        }
    }
}
