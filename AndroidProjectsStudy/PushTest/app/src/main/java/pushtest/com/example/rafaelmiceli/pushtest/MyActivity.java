package pushtest.com.example.rafaelmiceli.pushtest;

import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.os.AsyncTask;
import com.google.android.gms.gcm.*;
import com.microsoft.windowsazure.messaging.*;
import com.microsoft.windowsazure.notifications.NotificationsManager;


public class MyActivity extends Activity {

    private String SENDER_ID = "709979546467";
    private GoogleCloudMessaging gcm;
    private NotificationHub hub;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_my);

        NotificationsManager.handleNotifications(this, SENDER_ID, MyHandler.class);

        gcm = GoogleCloudMessaging.getInstance(this);

        String connectionString = "c2D7nWLIc+3h8CCrLvsPvpXUQkrmmSGJe9UdWiL/xcU=";
        hub = new NotificationHub("https://arduinoapphub-ns.servicebus.windows.net/arduinoapphub", connectionString, this);

        registerWithNotificationHubs();
    }

    @SuppressWarnings("unchecked")
    private void registerWithNotificationHubs() {
        new AsyncTask() {
            @Override
            protected Object doInBackground(Object... params) {
                try {
                    String regid = gcm.register(SENDER_ID);
                    hub.register(regid);
                } catch (Exception e) {
                    return e;
                }
                return null;
            }
        }.execute(null, null, null);
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
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}
