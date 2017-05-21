package pf.com.butterfly.module.bored;

import android.graphics.drawable.AnimationDrawable;
import android.media.MediaPlayer;
import android.os.Message;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import com.google.gson.Gson;

import pf.com.butterfly.R;
import pf.com.butterfly.adapter.ListViewAdapter;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.http.BmobHttp;
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

        mAdapter = new ListViewAdapter(R.layout.list_item_voice,AudioItemView.class.getName());
        voiceList.setAdapter(mAdapter);
        voiceList.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
//
//                if (animation != null) {
//                    voiceAnim
//                            .setBackgroundResource(R.drawable.icon_voice_ripple);
//                    voiceAnim = null;
//                }
//                voiceAnim = view.findViewById(R.id.voiceAnim);
//                voiceAnim.setBackgroundResource(R.drawable.anim_play_audio);
//                animation = (AnimationDrawable) voiceAnim.getBackground();
//                animation.start();
//
//                MediaManager.playSound(((Recorder)mAdapter.getItem(position)).filePath,
//                        new MediaPlayer.OnCompletionListener() {
//                            @Override
//                            public void onCompletion(MediaPlayer mp) {
//                                voiceAnim.setBackgroundResource(R.drawable.icon_voice_ripple);
//                            }
//                        });

            }
        });

        http=new BmobHttp(new IMsgHandler()
        {
            @Override
            public void onMsgDispose(Message msg)
            {
                OnMessage(msg);
            }
        });


        http.setContentType(MixFun.getContentType(".amr"));
    }

    class MyAudioRecordFinishListener implements AudioRecordButton.AudioRecordFinishListener
    {

        @Override
        public void onFinish(float second, String filePath)
        {
            // TODO Auto-generated method stub
            Recorder recorder = new Recorder(second, filePath);
            mAdapter.addOneItem(recorder);

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
    private void OnMessage(Message msg)
    {
        if(msg.arg2==-99 ||msg.arg2==-100 )
        {
            http.errerDispose(msg);
            return ;
        }

        BmobHttp.fileback res =new Gson().fromJson(msg.obj.toString(),BmobHttp.fileback.class);

        if(res==null)
        {
            HDLog.Toast("解析出错");
            return;
        }

    }

}
