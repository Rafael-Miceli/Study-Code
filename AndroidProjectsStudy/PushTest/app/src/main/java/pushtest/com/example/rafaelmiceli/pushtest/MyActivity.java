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

    private String SENDER_ID = "GCM project number";
    private GoogleCloudMessaging gcm;
    private NotificationHub hub;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_my);

        NotificationsManager.handleNotifications(this, SENDER_ID, MyHandler.class);

        gcm = GoogleCloudMessaging.getInstance(this);

        String connectionString = "W.A. Connection String in portuguese (Cadeia de Conexão)";
        hub = new NotificationHub("Notification Hub Name (not entire url)", connectionString, this);

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
}
