package pf.com.butterfly.module.bored;

import android.view.View;
import android.widget.TextView;

import pf.com.butterfly.R;
import pf.com.butterfly.adapter.DataItem;
import pf.com.butterfly.component.BenefitItemBar;
import pf.com.butterfly.model.BenefitItemData;

/**
 * Created by admin on 2017/5/17.
 */

public class AudioItem extends DataItem
{
    private TextView t_time;//时间

    @Override
    public void init(View view)
    {
        t_time=(TextView)view.findViewById(R.id.textLength);
    }

    @Override
    public void setData(Object obj)
    {
        Recorder recorder=(Recorder)obj;

        t_time.setText(Math.round(recorder.audioLength) + "\"");
    }
}
