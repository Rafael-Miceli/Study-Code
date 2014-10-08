package androidolderversion.com.example.rafael.myapplicationolderversion;

import android.content.Context;
import android.content.SharedPreferences;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by rafael.miceli on 06/10/2014.
 */
public class ImageAdapter extends BaseAdapter {

    public static final String SUBJECTS_NAME = "SubjectsFile";
    private Context mContext;

    public List<String> Subjects;

    public ImageAdapter(Context context){
        mContext = context;
        Subjects = new ArrayList<String>();

        Subjects.add("Android Development");
        Subjects.add("Java Web II");
        Subjects.add(".Net I");

    }

    @Override
    public int getCount() {
        return Subjects.size();
    }

    @Override
    public Object getItem(int i) {
        return null;
    }

    @Override
    public long getItemId(int i) {
        return 0;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        TextView textView;

        if (view == null){
            textView = new TextView(mContext);
        } else {
            textView = (TextView)view;
        }

        textView.setText(Subjects.get(i));

        return textView;
    }
}
