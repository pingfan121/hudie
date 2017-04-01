package pf.com.butterfly.component;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Matrix;
import android.text.Editable;
import android.text.Spannable;
import android.text.SpannableString;
import android.text.style.ImageSpan;
import android.util.AttributeSet;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewTreeObserver;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;

import java.util.List;

import pf.com.butterfly.R;

/**
 * 当前类注释: EditText 实现图文混排
 * 项目名：FastDevTest
 * 包名：com.jwenfeng.fastdev.view.htmledittext
 * 作者：jinwenfeng on 16/1/27 10:21
 * 邮箱：823546371@qq.com
 * QQ： 823546371
 * 公司：南京穆尊信息科技有限公司
 * © 2016 jinwenfeng
 * ©版权所有，未经允许不得传播
 */
public class HtmlEditText extends LinearLayout {

    public interface OnChoosePicListener {
        void onChoose();
    }

    private OnChoosePicListener onChoosePicListener;

    public void setOnChoosePicListener(OnChoosePicListener onChoosePicListener) {
        this.onChoosePicListener = onChoosePicListener;
    }

    public HtmlEditText(Context context, AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        init(context);
    }

    public HtmlEditText(Context context, AttributeSet attrs) {
        super(context, attrs);
        init(context);
    }

    public HtmlEditText(Context context) {
        super(context);
        init(context);
    }

    private Context context;
    private ImageView choose;
    private EditText et;
    private int width;

    private void init(Context context) {
        this.context = context;

    }

    /**
     * 设置图片宽度，默认为控件的宽度
     *
     * @param width
     */
    public void setWidth(int width) {
        this.width = width;
    }

    public EditText getEditText() {
        return et;
    }

    /**
     * 设置图片宽度，默认为控件的宽度
     *
     * @param htmlFile 上传图片的本地文件和服务器图片路径
     */
    public void setUploadPath(HtmlFile htmlFile) {
        insertImageSpan(htmlFile);
    }

    /**
     * 设置图片宽度，默认为控件的宽度
     *
     * @param fileList 上传图片的本地文件和服务器图片的集合
     */
    public void setUploadPaths(List<HtmlFile> fileList) {
        for (int i = 0; i < fileList.size(); i++) {
            insertImageSpan(fileList.get(i));
        }
    }

    private void insertImageSpan(HtmlFile htmlFile) {
        // 根据Bitmap对象创建ImageSpan对象
        // 计算缩放比例
        Bitmap loadedImage = BitmapFactory.decodeFile(htmlFile.getLocalPath());
        float scaleWidth = ((float) width) / loadedImage.getWidth();
        // 取得想要缩放的matrix参数
        Matrix matrix = new Matrix();
        matrix.postScale(scaleWidth, scaleWidth);
        loadedImage = Bitmap.createBitmap(loadedImage, 0, 0, loadedImage.getWidth(), loadedImage.getHeight(), matrix,
                true);
        ImageSpan imageSpan = new ImageSpan(context, loadedImage);
        // 创建一个SpannableString对象，以便插入用ImageSpan对象封装的图像
        String tempUrl = "<img src=\"" + htmlFile.getUrlPath() + "\" />";
        SpannableString spannableString = new SpannableString(tempUrl);
        // 用ImageSpan对象替换你指定的字符串
        spannableString.setSpan(imageSpan, 0, tempUrl.length(), Spannable.SPAN_EXCLUSIVE_EXCLUSIVE);
        // 将选择的图片追加到EditText中光标所在位置
        int index = et.getSelectionStart(); // 获取光标所在位置
        Editable edit_text = et.getEditableText();
        if (index < 0 || index >= edit_text.length()) {
            edit_text.append(spannableString);
        } else {
            edit_text.insert(index, spannableString);
        }
        edit_text.insert(index + spannableString.length(), "\n");
        Log.d("测试:","插入的图片：" + spannableString.toString());
    }

}
