package pf.com.butterfly.module.bored;

import android.graphics.drawable.AnimationDrawable;
import android.media.MediaPlayer;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

import pf.com.butterfly.MainActivity;
import pf.com.butterfly.R;
import pf.com.butterfly.adapter.Adapter;
import pf.com.butterfly.base.AppBaseControl;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.message.Protocols.login_req;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.title.TitleModule;

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

    protected void initValue()
    {
        title="无聊";
        layout=R.layout.bored_head;
    }

    private ListView voiceList;
    private AudioRecordButton btn_record;

    private Adapter<Recorder> mAdapter;

    private AnimationDrawable animation;
    private View voiceAnim;

    @Override
    public void initControl()
    {

        voiceList=(ListView)view.findViewById(R.id.listView);

        btn_record=(AudioRecordButton)view.findViewById(R.id.btn_record);

        btn_record.setAudioRecordFinishListener(new MyAudioRecordFinishListener());

        mAdapter = new Adapter<Recorder>(R.layout.list_item_voice,AudioItem.class.getName());
        voiceList.setAdapter(mAdapter);
        voiceList.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {

                if (animation != null) {
                    voiceAnim
                            .setBackgroundResource(R.drawable.icon_voice_ripple);
                    voiceAnim = null;
                }
                voiceAnim = view.findViewById(R.id.voiceAnim);
                voiceAnim.setBackgroundResource(R.drawable.anim_play_audio);
                animation = (AnimationDrawable) voiceAnim.getBackground();
                animation.start();

                MediaManager.playSound(((Recorder)mAdapter.getItem(position)).filePath,
                        new MediaPlayer.OnCompletionListener() {
                            @Override
                            public void onCompletion(MediaPlayer mp) {
                                voiceAnim.setBackgroundResource(R.drawable.icon_voice_ripple);
                            }
                        });

            }
        });
    }

    class MyAudioRecordFinishListener implements AudioRecordButton.AudioRecordFinishListener
    {

        @Override
        public void onFinish(float second, String filePath)
        {
            // TODO Auto-generated method stub
            Recorder recorder = new Recorder(second, filePath);
            mAdapter.AddOneItem(recorder);
        }

    }

}
