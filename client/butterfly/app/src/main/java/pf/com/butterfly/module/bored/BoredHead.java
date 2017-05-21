package pf.com.butterfly.module.bored;

import android.graphics.drawable.AnimationDrawable;
import android.media.MediaPlayer;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ListView;

import pf.com.butterfly.R;
import pf.com.butterfly.adapter.ListViewAdapter;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.input.TextInput;
import pf.com.butterfly.module.bored.BoredDetail;
import pf.com.butterfly.module.bored.BoredItemView;
import pf.com.butterfly.module.bored.MediaManager;
import pf.com.butterfly.module.bored.Recorder;
import pf.com.butterfly.util.HDLog;

/**
 * Created by admin on 2017/3/3.
 */
public class BoredHead extends AppBaseViewControl
{
    private static BoredHead _instance;

    public static BoredHead getInstance()
    {
        if(_instance==null)
        {
            _instance=new BoredHead();
        }

        return _instance;
    }

    public void initValue()
    {
        title="无聊";
        layout=R.layout.bored_head;
    }

    private ListViewAdapter adapter;

    private EditText et_text;

    private ListView listView;

    @Override
    public void initControl()
    {
        view.findViewById(R.id.btn_add).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OnTiJiao();
            }
        });

        listView=(ListView)view.findViewById(R.id.listView);

        adapter=new ListViewAdapter(R.layout.bored_head_item, BoredItemView.class.getName());

        listView.setAdapter(adapter);
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {

              //点击了列表
                BoredDetail.getInstance().show();

            }
        });

        et_text=(EditText)view.findViewById(R.id.et_text);
    }

    public void OnTiJiao()
    {
        //检测文本是否合法

        String str=et_text.getText().toString();

        if(str.equals(""))
        {
            HDLog.Toast("请输入您的文本");
            return ;
        }

        if(str.length()>30)
        {
            HDLog.Toast("文本长度过长,请重新输入");
            return ;
        }

        //发送给服务器....
        OnMsgBack();

    }

    public void OnMsgBack()
    {
        BoredHeadItemData data=new BoredHeadItemData();
        data.icon="";
        data.name="我是一个平凡的人";
        data.text=et_text.getText().toString();
        data.num=20;

        adapter.addOneItem(data);
        listView.smoothScrollToPosition(listView.getCount() - 1);//移动到尾部
    }

}
