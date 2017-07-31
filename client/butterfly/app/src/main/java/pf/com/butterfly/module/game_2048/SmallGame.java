package pf.com.butterfly.module.game_2048;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Random;

import pf.com.butterfly.component.game_2048_view;

class SmallGame
{

    private NumGrid[][] grids = null;
    private int num;

    public void init(int num)
    {
        this.num = num;

        grids = new NumGrid[num][];

        for(int i=0;i<grids.length;i++)
        {
            grids[i] = new NumGrid[grids.length];
        }

        startGame();
    }



    public void startGame()
    {
        cleanGrid();

        addGrid();
        addGrid();

        TestGameHead.getInstance().resetView();
    }

    //向右移动
    private List<NumGrid> sortlist = new ArrayList<>();

    private Boolean left_move()
    {
        //首先 将所有的格子移动到右边去
        Boolean oper1 = false;
        Boolean oper2 = false;

        sortlist.clear();


        for(int i=0; i < grids.length; i++)
        {
            sortlist.clear();

            for(int k = 0; k < grids[i].length; k++)
            {
                sortlist.add(grids[i][k]);
            }

            oper1 =sort(sortlist);

            if(oper1 == true)
            {
                oper2 = true;
            }
        }
        return oper2;
    }

    private Boolean right_move()
    {
        //首先 将所有的格子移动到右边去
        Boolean oper1 = false;
        Boolean oper2 = false;

        sortlist.clear();


        for(int i = 0; i < grids.length; i++)
        {
            sortlist.clear();

            for(int k = grids[i].length-1; k >=0; k--)
            {
                sortlist.add(grids[i][k]);
            }

            oper1 = sort(sortlist);

            if(oper1 == true)
            {
                oper2 = true;
            }
        }
        return oper2;
    }

    private Boolean up_move()
    {
        //首先 将所有的格子移动到右边去
        Boolean oper1 = false;
        Boolean oper2 = false;

        sortlist.clear();


        for(int i = 0; i < grids.length; i++)
        {
            sortlist.clear();

            for(int k = 0; k < grids[i].length; k++)
            {
                sortlist.add(grids[k][i]);
            }

            oper1 = sort(sortlist);

            if(oper1 == true)
            {
                oper2 = true;
            }
        }
        return oper2;
    }

    private Boolean down_move()
    {
        //首先 将所有的格子移动到右边去
        Boolean oper1 = false;
        Boolean oper2 = false;

        sortlist.clear();


        for(int i = 0; i < grids.length; i++)
        {
            sortlist.clear();

            for(int k = grids[i].length - 1; k >= 0; k--)
            {
                sortlist.add(grids[k][i]);
            }

            oper1 = sort(sortlist);

            if(oper1 == true)
            {
                oper2 = true;
            }
        }
        return oper2;
    }

    public Boolean sort(List<NumGrid> arr)
    {
        Boolean oper1 = false;
        Boolean oper2 = false;
        Boolean oper3 = false;


        while(true)
        {
            oper1 = moveGrid(arr);
            oper2 = mergeGrid(arr);

            if(oper1 ==true || oper2==true)
            {
                oper3 = true;
            }

            if(oper1 == false && oper2 == false)
            {
                break;
            }
        }
        return oper3;
    }

    //得到空格位置
    public Boolean moveGrid(List<NumGrid> arr)
    {
        Boolean oper = false;

        int index = getVan(arr);

        if(index == -1)
            return false;

        for(int i = 0; i < arr.size(); i++)
        {
            NumGrid grid=arr.get(i);
            if(grid.num != 0)
            {
                if(i > index)
                {
                    arr.get(index).num = arr.get(i).num;
                    arr.get(i).num = 0;

                    index = getVan(arr);

                    oper = true;
                }
            }
        }

        return oper;
    }
    //合并格子
    public Boolean mergeGrid(List<NumGrid> arr)
    {
        Boolean oper = false;

        for(int i = 0; i < arr.size() - 1; i++)
        {
            if(arr.get(i).num == arr.get(i+1).num && arr.get(i).num != 0 && arr.get(i).merge == false && arr.get(i+1).merge == false)
            {
                arr.get(i).num += arr.get(i).num;
                arr.get(i+1).num = 0;
                arr.get(i).merge = true;
                oper = true;
            }
        }
        return oper;
    }

    //移动位置
    public int getVan(List<NumGrid> arr)
    {
        for(int i = 0; i < arr.size(); i++)
        {
            if(arr.get(i).num == 0)
            {
                return i;
            }
        }
        return -1;
    }

    public void addGrid()
    {
        sortlist.clear();

        for(int i = 0; i < grids.length; i++)
        {
            for(int k = 0; k < grids[i].length; k++)
            {
                if(grids[i][k].num==0)
                {
                    sortlist.add(grids[i][k]);
                }

            }
        }

        NumGrid grid = sortlist.get(new Random().nextInt(sortlist.size()));
        grid.num = 2;
    }

    public NumGrid[][] getGrids()
    {
        return  grids;
    }

    //检测游戏是否结束
    public Boolean isOver()
    {
        //先检测是否有空格子

        for(int i = 0; i < grids.length; i++)
        {
            for(int k = 0; k < grids[i].length; k++)
            {
                if(grids[i][k].num == 0)
                {
                    return false;
                }
            }
        }

        //判断相邻两个是否相同

        for(int i = 0; i < grids.length; i++)
        {
            for(int k = 0; k < grids[i].length-1; k++)
            {
                if(grids[i][k].num == grids[i][k+1].num)
                {
                    return false;
                }
            }
        }

        for(int i = 0; i < grids.length-1; i++)
        {
            for(int k = 0; k < grids[i].length; k++)
            {
                if(grids[i][k].num == grids[i+1][k].num)
                {
                    return false;
                }
            }
        }

        return true;
    }

    //是否赢了
    public Boolean isWin()
    {
        //先检测是否有空格子

        for(int i = 0; i < grids.length; i++)
        {
            for(int k = 0; k < grids[i].length; k++)
            {
                if(grids[i][k].num == 2048)
                {
                    return true;
                }
            }
        }

        return false;
    }




    //格子相关的...
    //清理
    private void cleanGrid()
    {
        for(int i=0;i<grids.length;i++)
        {
            for(int k = 0; k < grids[i].length; k++)
            {
                if(grids[i][k] == null)
                {
                    grids[i][k] = new NumGrid();
                }
                else
                {
                    grids[i][k].num = 0;
                }
            }
        }
    }




    //设置方向
    public void OperGame(String dir)
    {
        Boolean oper = false;

        if(dir == "up")
        {
            oper=up_move();
        }
        if(dir == "down")
        {
            oper = down_move();
        }
        if(dir == "left")
        {
            oper = left_move();
        }
        if(dir == "right")
        {
            oper = right_move();
        }

        for(int i = 0; i < grids.length; i++)
        {
            for(int k = 0; k < grids[i].length; k++)
            {
                grids[i][k].merge = false;
            }
        }

        if(oper == true)
        {
            //增加格子
            addGrid();
            //判断输赢
        }

        TestGameHead.getInstance().resetView();
    }

}

