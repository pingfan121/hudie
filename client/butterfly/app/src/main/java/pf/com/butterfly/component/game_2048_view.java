package pf.com.butterfly.component;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.view.View;

import java.util.HashMap;
import java.util.Map;

import pf.com.butterfly.module.game_2048.NumGrid;
import pf.com.butterfly.module.game_2048.TestGameHead;
import pf.com.butterfly.util.Point;

/**
 * Created by admin on 2017/7/31.
 */

public class game_2048_view extends View
{
    public game_2048_view(Context context, AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        init(context);
    }

    public game_2048_view(Context context, AttributeSet attrs) {
        super(context, attrs);
        init(context);
    }

    public game_2048_view(Context context) {
        super(context);
        init(context);
    }

    private void init(Context context)
    {
        setColor();
    }

    public void setGrids(NumGrid[][] grids)
    {
        this.grids=grids;
    }

    public void resetView()
    {
        this.invalidate();
    }

    private int gap = 4;
    private int width;

    private int grid_width;

    public NumGrid[][] grids;

    //画图
    @Override
    protected void onDraw(Canvas canvas)
    {
        super.onDraw(canvas);

        canvas.getWidth();

        int width = canvas.getWidth();

        grid_width = (width - (grids.length+1) * gap) / grids.length;

        Paint p = new Paint();
        p.setColor(Color.BLACK);// 设置黑色

        canvas.drawRect(0,0,width,width,p);

        Paint textPaint = new Paint();
        textPaint.setColor(Color.WHITE);
        textPaint.setTextSize(grid_width/3);
        textPaint.setStyle(Paint.Style.FILL);
        textPaint.setTextAlign(Paint.Align.CENTER);

        Paint.FontMetrics fontMetrics = textPaint.getFontMetrics();
        float top = fontMetrics.top;//为基线到字体上边框的距离,即上图中的top
        float bottom = fontMetrics.bottom;//为基线到字体下边框的距离,即上图中的bottom

        int baseLineY = (int) (grid_width/2 - top/2 - bottom/2);//基线中间点的y轴计算公式


        for(int i = 0; i < grids.length; i++)
        {
            for(int k = 0; k < grids[i].length; k++)
            {

                NumGrid grid = grids[i][k];

                if(grid.num != 0)
                {
                    int starty = gap + i * grid_width + i * gap;
                    int startx = gap + k * grid_width + k * gap;

                    p = new Paint();
                    p.setColor(colors.get(grid.num));

                    canvas.drawRect(startx, starty, startx+grid_width, starty+grid_width,p);

                    canvas.drawText(grids[i][k].num+"",startx+grid_width/2,starty+baseLineY,textPaint);
                }
            }
        }

    }

    private Point p1=new Point();
    private Point p2=new Point();

    @Override
    public boolean onTouchEvent(MotionEvent event)
    {
        int action = event.getAction();

        switch (action)
        {
            case MotionEvent.ACTION_DOWN:
            {
                p1.X=event.getX();
                p1.Y=event.getY();

                break;
            }
            case MotionEvent.ACTION_UP:
            {
                p2.X=event.getX();
                p2.Y=event.getY();

                TestGameHead.getInstance().MoveView(p1,p2);
                break;
            }
            default:
                break;
        }

        return true;
    }

    private Map<Integer, Integer> colors = new HashMap<>();

    private void setColor()
    {
        colors.clear();

        colors.put(2, 0xffca8687);
        colors.put(4, 0xfffaa755);
        colors.put(8, 0xffb7ba6b);
        colors.put(16, 0xfff391a9);
        colors.put(32, 0xfffab27b);
        colors.put(64, 0xffb2d235);
        colors.put(128, 0xffbd6758);
        colors.put(256, 0xfff58220);
        colors.put(512, 0xff5c7a29);
        colors.put(1024, 0xffd93a49);
        colors.put(2048, 0xff843900);
    }
}
