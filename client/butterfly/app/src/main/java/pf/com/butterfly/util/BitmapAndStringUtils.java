package pf.com.butterfly.util;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Base64;

import java.io.ByteArrayOutputStream;

/**
 * 微博：http://weibo.com/mcxiaobing
 * ============================================================================
 * Copyright (c) 2015-2016 QQ986945193 All rights reserved.
 * ----------------------------------------------------------------------------
 * 类名：Android开发之常用必备工具类图片bitmap转成字符串string与String字符串转换为bitmap图片格式
 * ----------------------------------------------------------------------------
 * 功能描述：Android开发之常用必备工具类图片bitmap转成字符串string与String字符串转换为bitmap图片格式
 * ----------------------------------------------------------------------------
 */
public class BitmapAndStringUtils
{
    /**
     * 图片转成string
     *
     * @param bitmap
     * @return
     */
    public static String convertIconToString(Bitmap bitmap)
    {

        ByteArrayOutputStream baos = new ByteArrayOutputStream();// outputstream
        bitmap.compress(Bitmap.CompressFormat.JPEG, 100, baos);
        byte[] appicon = baos.toByteArray();// 转为byte数组
        return Base64.encodeToString(appicon, Base64.DEFAULT);

    }

    /**
     * string转成bitmap
     *
     * @param st
     */
    public static Bitmap convertStringToIcon(String st)
    {
        // OutputStream out;
        Bitmap bitmap = null;
        try
        {
            // out = new FileOutputStream("/sdcard/aa.jpg");
            byte[] bitmapArray;
            bitmapArray = Base64.decode(st, Base64.DEFAULT);
            bitmap =
                    BitmapFactory.decodeByteArray(bitmapArray, 0,
                            bitmapArray.length);
            // bitmap.compress(Bitmap.CompressFormat.PNG, 100, out);
            return bitmap;
        }
        catch (Exception e)
        {
            HDLog.error(e);
            return null;
        }
    }
}