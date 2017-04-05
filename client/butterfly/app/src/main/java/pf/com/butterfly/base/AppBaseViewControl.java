package pf.com.butterfly.base;

import android.view.LayoutInflater;
import android.view.View;
import android.widget.FrameLayout;

import pf.com.butterfly.ControlManager;
import pf.com.butterfly.MainActivity;
import pf.com.butterfly.R;
import pf.com.butterfly.module.title.TitleModule;

/**
 * Created by admin on 2017/3/3.
 */
public abstract class AppBaseViewControl
{
    protected int layout;

    protected View view;

    public String title;//界面标题

    public int visible=View.INVISIBLE;

    public AppBaseViewControl()
    {
        initValue();
    }


    protected abstract void initValue();

    private void resetView()
    {
        FrameLayout father = (FrameLayout)MainActivity.main.findViewById(R.id.control_view);

        if(view==null)
        {
            LayoutInflater inflater = LayoutInflater.from(father.getContext());

            view = inflater.inflate(layout, null);

            ((FrameLayout)father).addView(view);

            initControl();
        }
        else
        {
            int count = father.getChildCount();

            int flag=0;

            for (int i = 0; i < count; i++)
            {
                View v = father.getChildAt(i);

                if(v ==view )
                {
                    flag=1;
                    break;
                }
            }

            if(flag==0)
            {
                father.addView(view);
            }
        }
    }

    //初始化子控件
    protected abstract void initControl();

    public void resetState()
    {

        if(visible ==View.INVISIBLE)
        {
            hide();
        }
        else
        {
            show();
        }
    }

    protected void resetTitle()
    {
        TitleModule.getInstance().SetTitle(title);
    }

    public void show()
    {

        resetView();

        view.setVisibility(View.VISIBLE);
        visible=View.VISIBLE;

        resetTitle();

        ControlManager.show(this);
    }

    public void hide()
    {
        if(view!=null)
        {
            view.setVisibility(View.INVISIBLE);
            visible=View.INVISIBLE;

            ControlManager.hide(this);
        }

    }

    public View getView()
    {
        return view;
    }




}