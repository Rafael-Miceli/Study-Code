package oauthfacebook.com.example.rafaelmiceli.applicationoauthfacebook;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;


public class MyProfile extends Activity implements ListView.OnItemClickListener {

    private NavigationDrawerHelper mNavigationDrawerHelper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_my_profile);

        mNavigationDrawerHelper = new NavigationDrawerHelper();
        mNavigationDrawerHelper.init(this, this);
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

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        if (position == 4)
        {
            Intent intent = new Intent(this, Logout.class);
            startActivity(intent);
        }

        mNavigationDrawerHelper.handleSelect(position);
    }
}
