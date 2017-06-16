package pf.com.butterfly.module.bored;

import android.graphics.drawable.AnimationDrawable;
import android.media.MediaPlayer;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.List;

import pf.com.butterfly.R;
import pf.com.butterfly.adapter.AdapterItemData;
import pf.com.butterfly.adapter.ListViewAdapter;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.http.BmobHttp;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.Protocols.bored_head_item_add_res;
import pf.com.butterfly.message.Protocols.bored_record_item_add_req;
import pf.com.butterfly.message.Protocols.bored_record_item_add_res;
import pf.com.butterfly.message.Protocols.bored_record_items_req;
import pf.com.butterfly.message.Protocols.bored_record_items_res;
import pf.com.butterfly.message.net.IMsgResult;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.ControlLayer;
import pf.com.butterfly.util.HDLog;
import pf.com.butterfly.util.MixFun;

/**
 * Created by admin on 2017/3/3.
 */
public class BoredDetail extends AppBaseViewControl
{
    private static BoredDetail _instance;

    public static BoredDetail getInstance()
    {
        if(_instance==null)
        {
            _instance=new BoredDetail();
        }

        return _instance;
    }

    protected void initValue()
    {
        title="无聊";
        layout=R.layout.bored_detail;
        layer= ControlLayer.module_view1;
    }

    private ListView voiceList;
    private AudioRecordButton btn_record;

    private ListViewAdapter mAdapter;

    private AnimationDrawable animation;
    private View voiceAnim;

    private BmobHttp http;

    @Override
    public void initControl()
    {

        voiceList=(ListView)view.findViewById(R.id.listView);

        btn_record=(AudioRecordButton)view.findViewById(R.id.btn_record);

        btn_record.setAudioRecordFinishListener(new MyAudioRecordFinishListener());

        mAdapter = new ListViewAdapter(R.layout.list_item_voice,BoredAudioItemView.class.getName());
        voiceList.setAdapter(mAdapter);
        voiceList.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {

                if (animation != null)
                {
                    voiceAnim.setBackgroundResource(R.drawable.icon_voice_ripple);
                    voiceAnim = null;
                }
                voiceAnim = view.findViewById(R.id.iv);
                voiceAnim.setBackgroundResource(R.drawable.anim_play_audio);
                animation = (AnimationDrawable) voiceAnim.getBackground();
                animation.start();

                MediaManager.playSound(((BoredAudioItemData)mAdapter.getItem(position)).iteminfo.recordurl,
                        new MediaPlayer.OnCompletionListener() {
                            @Override
                            public void onCompletion(MediaPlayer mp) {
                                voiceAnim.setBackgroundResource(R.drawable.icon_voice_ripple);
                            }
                        });

            }
        });

        http=new BmobHttp(new IMsgHandler()
        {
            @Override
            public void onMsgDispose(int err,String result,Object userToken)
            {
                OnMessage(err,result,userToken);
            }
        });


        http.setContentType(MixFun.getContentType(".amr"));
    }

    private  String headid="";

    public void ShowView(String bored_head_id)
    {
        //必须先调用显示..
        this.show();

        if( headid!=bored_head_id)
        {
            mAdapter.datas.clear();
            mAdapter.notifyDataSetChanged();

            headid=bored_head_id;

            updateData();
        }
    }

    class MyAudioRecordFinishListener implements AudioRecordButton.AudioRecordFinishListener
    {

        @Override
        public void onFinish(float second, String filePath)
        {
            try
            {
                HDLog.error("录音地址:"+filePath);

                http.sendAudioFile(filePath);

                //等待一会....这里应该播放上传动画
                //.....
            }
            catch (Exception ex)
            {
                HDLog.error("上传录音出现问题出现异常");
                HDLog.error(ex);
            }
        }

    }
    public static String getupname(String filename)
    {
        String type=filename.substring(filename.length()-4,filename.length());

        String name= ""+System.currentTimeMillis()+type;

        return name;
    }

    //处理http返回
    private void OnMessage(int err,String result,Object userToken)
    {
        if(err==-99 ||err==-100 )
        {
            http.errerDispose(err,result);
            return ;
        }

        BmobHttp.fileback res =new Gson().fromJson(result,BmobHttp.fileback.class);

        if(res==null)
        {
            HDLog.Toast("解析出错");
            return;
        }

        //把数据发送给服务器
        bored_record_item_add_req req=new bored_record_item_add_req();

        req.head_id=headid;
        req.time=1;
        req.url=res.url;

        NetManager.SendMsg(req,add_result);

    }

    //发送网络消息
    public void updateData()
    {
        bored_record_items_req req=new bored_record_items_req();
        req.head_id=headid;

        NetManager.SendMsg(req,update_result);

        //播放发送动画.....
    }


    //添加录音返回...
    public void boredRecordAddback(bored_record_item_add_res res)
    {
        Recorder data=new Recorder(res.info.recordlength,res.info.recordurl);

        mAdapter.addOneItem(data);
    }


    //消息返回处理.......

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
            HDLog.Toast("已提交");
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

            List<AdapterItemData> datas=new ArrayList<AdapterItemData>();

            bored_record_items_res res=(bored_record_items_res)msg;

            for(int i=0;i<res.infos.length;i++)
            {
                BoredAudioItemData data=new BoredAudioItemData();
                data.iteminfo=res.infos[i];
                datas.add(data);
            }

            mAdapter.datas=datas;
            mAdapter.notifyDataSetChanged();
        }
    };



}
