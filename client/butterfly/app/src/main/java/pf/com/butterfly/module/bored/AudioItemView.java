package pf.com.butterfly.module.bored;

import android.view.View;
import android.widget.TextView;

import pf.com.butterfly.R;
import pf.com.butterfly.adapter.AdapterItemData;
import pf.com.butterfly.adapter.AdapterItemControl;

/**
 * Created by admin on 2017/5/17.
 */

public class AudioItemView extends AdapterItemControl
{
    private TextView t_time;//时间

    @Override
    public void init(View view)
    {
        t_time=(TextView)view.findViewById(R.id.tv_time);
    }

    @Override
    public void setData(AdapterItemData obj)
    {
        Recorder recorder=(Recorder)obj;

        t_time.setText(Math.round(recorder.audioLength) + "\"");
    }
}
