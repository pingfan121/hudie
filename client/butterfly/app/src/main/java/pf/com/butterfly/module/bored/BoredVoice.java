package pf.com.butterfly.module.bored;

import android.graphics.drawable.AnimationDrawable;
import android.media.MediaPlayer;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import pf.com.butterfly.R;
import pf.com.butterfly.adapter.AdapterItemData;
import pf.com.butterfly.adapter.ListViewAdapter;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.okhttp.IMsgback;
import pf.com.butterfly.bmob.BmobHttp;
import pf.com.butterfly.infofile.res_bored_voicelist;
import pf.com.butterfly.manager.MediaManager;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.Protocols.bored_record_item_add_req;
import pf.com.butterfly.message.Protocols.bored_record_item_add_res;
import pf.com.butterfly.message.net.IMsgResult;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.okhttp.OkHttpBmob;
import pf.com.butterfly.okhttp.OkHttpUtils;
import pf.com.butterfly.util.HDLog;
import pf.com.butterfly.util.MyGson;

/**
 * Created by admin on 2017/3/3.
 */
public class BoredVoice extends AppBaseViewControl
{
    private static BoredVoice _instance;

    public static BoredVoice getInstance()
    {
        if(_instance==null)
        {
            _instance=new BoredVoice();
            _instance.layer = BoredHead.getInstance().layer+1;
        }

        return _instance;
    }

    protected void initValue()
    {
        title="无聊";
        layout=R.layout.bored_detail;
    }

    private ListView voiceList;
    private AudioRecordButton btn_record;

    private ListViewAdapter mAdapter;

    private AnimationDrawable animation;
    private View voiceAnim;

    //private BmobHttp http;

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

                MediaManager.playSound(((BoredAudioItemData)mAdapter.getItem(position)).iteminfo.voice_url,
                        new MediaPlayer.OnCompletionListener() {
                            @Override
                            public void onCompletion(MediaPlayer mp) {
                                voiceAnim.setBackgroundResource(R.drawable.icon_voice_ripple);
                            }
                        });

            }
        });

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

                OkHttpBmob.getInstance().upBmobAMRFile(filePath,upfile_result);

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
//    public static String getupname(String filename)
//    {
//        String type=filename.substring(filename.length()-4,filename.length());
//
//        String name= ""+System.currentTimeMillis()+type;
//
//        return name;
//    }

    //-----------------网络返回处理-------------------

    private IMsgback upfile_result=new IMsgback()
    {
        @Override
        public void onMsgDispose(int err, String result, Object userToken)
        {

            if(err!=0)
            {
                HDLog.Toast("出现错误__"+result);
                return ;
            }

            fileback res =MyGson.parseJson(result,fileback.class);

            if(res==null)
            {
                HDLog.Toast("解析出错");
                return;
            }

            HDLog.Toast("录音已提交到bmob");

            //把数据发送给服务器
            bored_record_item_add_req req=new bored_record_item_add_req();

            req.head_id=headid;
            req.time=1;
            req.url=res.url;
            Map<String,String> params=new HashMap<>();
            params.put("boredid",headid);


            NetManager.SendMsg(req,add_result);
        }
    };


    //发送网络消息
    public void updateData()
    {

        Map<String,String> params=new HashMap<>();

        params.put("boredid",headid);


        OkHttpUtils.getInstance().sendAppMsg("bored/voicelist",params,voicelist_result);

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

    private IMsgback voicelist_result=new IMsgback()
    {

        @Override
        public void onMsgDispose(int err, String result, Object userToken)
        {

            //取消发送动画...

            if(err!=0)
            {
                HDLog.Toast("获取语音列表出现错误.....");
                return ;
            }

            HDLog.Toast("已刷新");

            List<AdapterItemData> datas=new ArrayList<AdapterItemData>();

            res_bored_voicelist res= MyGson.parseJson(result,res_bored_voicelist.class);

            for(int i=0;i<res.list.length;i++)
            {
                BoredAudioItemData data=new BoredAudioItemData();
                data.iteminfo=res.list[i];
                datas.add(data);
            }

            mAdapter.datas=datas;
            mAdapter.notifyDataSetChanged();
        }
    };

    public class fileback
    {
        public String filename;
        public String url;
        public String cdnname;
    }

    public class errinfo
    {
        public int code;
        public String error;
    }



}
