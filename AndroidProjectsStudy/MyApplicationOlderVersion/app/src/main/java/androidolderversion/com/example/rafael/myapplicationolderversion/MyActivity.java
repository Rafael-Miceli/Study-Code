package androidolderversion.com.example.rafael.myapplicationolderversion;

import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Toast;


public class MyActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_my);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.my, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        if (id == R.id.action_grades) {
            onMenuItemGradeTouch();
            return true;
        }
        if (id == R.id.action_subjects) {
            onMenuItemSubjectTouch();
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    public void onMenuItemSubjectTouch(){
        Toast toast = Toast.makeText(this, "Indo para matérias", Toast.LENGTH_LONG);
        toast.show();
    }

    public void onMenuItemGradeTouch(){
        Toast toast = Toast.makeText(this, "Indo para notas", Toast.LENGTH_LONG);
        toast.show();
    }
}
