package pf.com.butterfly.module.game_2048;

import android.os.Message;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.google.gson.Gson;

import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseControl;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.component.game_2048_view;
import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.http.BmobHttp;
import pf.com.butterfly.message.Protocols.register_req;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.title.TitleModule;
import pf.com.butterfly.util.HDLog;
import pf.com.butterfly.util.Point;

/**
 * Created by admin on 2017/3/3.
 */
public class TestGameHead extends AppBaseViewControl
{
    private static TestGameHead _instance;

    public static TestGameHead getInstance()
    {
        if(_instance==null)
        {
            _instance=new TestGameHead();
        }
        return _instance;
    }

    private SmallGame game;

    protected void initValue()
    {
        title="2048";
        layout=R.layout.game_2048_head;
    }


    private game_2048_view gameview;
    @Override
    public void initControl()
    {
        gameview=(game_2048_view)view.findViewById(R.id.game_view);

        if(game==null)
        {
            game=new SmallGame();
        }

        game.init(4);

        gameview.setGrids(game.getGrids());


    }

    public void resetView()
    {
        gameview.resetView();
    }

    public void MoveView(Point orgPos, Point dirPos)
    {
        String dir=getdirection(orgPos,dirPos);

        if(dir!="")
        {
            game.OperGame(dir);
        }
    }


    public String getdirection(Point orgPos, Point dirPos)
    {
        Point TTpos = new Point();

        TTpos.X = (short)(dirPos.X - orgPos.X);
        TTpos.Y = (short)(dirPos.Y - orgPos.Y);

        float length = Math.max(Math.abs(TTpos.X), Math.abs(TTpos.Y));

        if(length < 5)
        {
            return "";
        }


        double tanx = Math.atan2(TTpos.Y, TTpos.X);

        double degrees = (180 / Math.PI) * tanx;

        while(degrees > 360)
        {
            degrees -= 360;
        }

        while(degrees < 0)
        {
            degrees += 360;
        }

        //角度得到了...怎么算方向
        if(degrees > 315 || degrees <= 45)   //朝右
        {
            return "right";
        }

        if(degrees > 45 && degrees <= 135)   //朝下
        {
            return "down";
        }

        if(degrees > 135 && degrees <= 225)   //朝左
        {
            return "left";
        }

        if(degrees > 225 && degrees <= 315)   //朝上
        {
            return "up";
        }

        return "";

    }




}

