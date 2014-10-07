package androidolderversion.com.example.rafael.myapplicationolderversion;

import android.app.Activity;
import android.media.ImageReader;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.List;


public class Subjects extends Activity {

    private EditText mEditTextWeight;
    private EditText mEditSubjectName;
    private GridView mGrdSubjects;
    private ImageAdapter imageAdapter;
    private List<String> Subjects;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_subjects);

        SetupViews();

        if (savedInstanceState != null) {

        }
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {

    }

    private void SetupViews() {
        Button btnSave = (Button)findViewById(R.id.btnSaveSubject);
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onBtnSaveClick(v);
            }
        });

        imageAdapter = new ImageAdapter(this);

        getmGrdSubjects().setAdapter(imageAdapter);
    }

    private void onBtnSaveClick(View view) {

        String subject = getmEditSubjectName().getText().toString();
        imageAdapter.Subjects.add(subject);
        getmGrdSubjects().setAdapter(imageAdapter);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.my_activity2, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    public EditText getmEditSubjectName() {
        if (mEditSubjectName == null)
            mEditSubjectName = (EditText)findViewById(R.id.txtSubjectName);

        return mEditSubjectName;
    }

    public EditText getmEditTextWeight() {
        if (mEditTextWeight == null)
            mEditTextWeight = (EditText)findViewById(R.id.editTextWeight);

        return mEditTextWeight;
    }

    public GridView getmGrdSubjects() {
        if (mGrdSubjects == null)
            mGrdSubjects = (GridView)findViewById(R.id.gridViewSubjects);
        return mGrdSubjects;
    }
}
