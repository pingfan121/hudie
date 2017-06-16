package pf.com.butterfly.module.bored;

import android.graphics.drawable.AnimationDrawable;
import android.media.MediaPlayer;
import android.support.v4.widget.SwipeRefreshLayout;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

import pf.com.butterfly.R;
import pf.com.butterfly.adapter.AdapterItemData;
import pf.com.butterfly.adapter.ListViewAdapter;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.hander.MsgHandler;
import pf.com.butterfly.input.TextInput;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.Protocols.bored_head_item_add_req;
import pf.com.butterfly.message.Protocols.bored_head_item_add_res;
import pf.com.butterfly.message.Protocols.bored_head_items_req;
import pf.com.butterfly.message.Protocols.bored_head_items_res;
import pf.com.butterfly.message.net.IMsgResult;
import pf.com.butterfly.message.net.NetManager;
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

    private SwipeRefreshLayout srl;

    @Override
    public void initControl()
    {
        view.findViewById(R.id.btn_add).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OnTiJiao();
            }
        });


        //下拉刷新布局

        srl=(SwipeRefreshLayout)view.findViewById(R.id.sr_update);

        //设置卷内的颜色
        srl.setColorSchemeResources(android.R.color.holo_blue_bright,
                android.R.color.holo_green_light, android.R.color.holo_orange_light, android.R.color.holo_red_light);
        //设置下拉刷新监听
        srl.setOnRefreshListener(new SwipeRefreshLayout.OnRefreshListener() {

            @Override
            public void onRefresh() {
               updateData(true);
            }
        });



        listView=(ListView)view.findViewById(R.id.listView);

        adapter=new ListViewAdapter(R.layout.bored_head_item, BoredItemView.class.getName());

        listView.setAdapter(adapter);
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {

                Object obj=view.getTag();

              //点击了列表
                BoredDetail.getInstance().ShowView(((BoredHeadItemData)adapter.getItem(position)).id);

            }
        });

        et_text=(EditText)view.findViewById(R.id.et_text);
    }

    @Override
    public void reShow()
    {
        srl.setRefreshing(false);

        updateData(false);
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

        //提交
        bored_head_item_add_req req=new bored_head_item_add_req();
        req.content=str;
        NetManager.SendMsg(req,add_result);

    }

    public void updateData(boolean flag)
    {
        if(flag==false)
        {
            if (adapter.datas.size() != 0)
                return;

            srl.setProgressViewOffset(false, 0, 30);
            srl.setRefreshing(true);
        }

        bored_head_items_req req=new bored_head_items_req();

        NetManager.SendMsg(req,update_result);


    }

    //-----------------网络返回处理-------------------

    private IMsgResult add_result=new IMsgResult()
    {
        @Override
        public void onError(int err, String msg)
        {
            HDLog.Toast(msg);
        }

        @Override
        public void onResult(MsgBase msg)
        {
            HDLog.Toast("提交成功");

            bored_head_item_add_res res=(bored_head_item_add_res)msg;

            BoredHeadItemData data=new BoredHeadItemData();
            data.id=res.info.id;
            data.icon="";
            data.name="我是一个平凡的人";
            data.text=res.info.content;
            data.num=res.info.rownum;

            adapter.addOneItem(data);
        }
    };


    private IMsgResult update_result=new IMsgResult()
    {
        @Override
        public void onError(int err, String msg)
        {
            HDLog.Toast(msg);
        }

        @Override
        public void onResult(MsgBase msg)
        {
            HDLog.Toast("已刷新");

            bored_head_items_res res=(bored_head_items_res)msg;

            List<AdapterItemData> datas=new ArrayList<AdapterItemData>();

            for(int i=0;i<res.infos.length;i++)
            {
                BoredHeadItemData data=new BoredHeadItemData();
                data.id=res.infos[i].id;
                data.icon="";
                data.name="我是一个平凡的人";
                data.text=res.infos[i].content;
                data.num=res.infos[i].rownum;

                datas.add(data);
            }

            adapter.datas=datas;
            adapter.notifyDataSetChanged();

            srl.setRefreshing(false);
        }
    };
}
