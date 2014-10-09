package androidolderversion.com.example.rafael.myapplicationolderversion;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

import androidolderversion.com.example.rafael.myapplicationolderversion.model.Subject;

/**
 * Created by rafael.miceli on 06/10/2014.
 */
public class ImageAdapter extends BaseAdapter {

    public static final String SUBJECTS_NAME = "SubjectsFile";
    private Context mContext;

    public List<Subject> SubjectsList;

    public ImageAdapter(Context context) {
        mContext = context;

        DatabaseHelper databaseHelper = new DatabaseHelper(context);

        SubjectsList = databaseHelper.getAllSubjects();
    }

    @Override
    public int getCount() {
        return SubjectsList.size();
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
    public View getView(int rowIndex, View view, ViewGroup viewGroup) {
        TextView textView;

        if (view == null){
            textView = new TextView(mContext);
        } else {
            textView = (TextView)view;
        }

        textView.setText(SubjectsList.get(rowIndex).getName());

        return textView;
    }
}
