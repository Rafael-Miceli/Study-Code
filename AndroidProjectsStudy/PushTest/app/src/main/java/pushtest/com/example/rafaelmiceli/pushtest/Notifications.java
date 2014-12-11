package pushtest.com.example.rafaelmiceli.pushtest;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.util.Log;
import android.widget.Toast;

import com.google.android.gms.gcm.GoogleCloudMessaging;
import com.microsoft.windowsazure.messaging.NotificationHub;

import java.util.Set;

/**
 * Created by rafael.miceli on 11/12/2014.
 */
public class Notifications {

    private static final String PREFS_NAME = "BreakingNewsCategories";
    private GoogleCloudMessaging gcm;
    private NotificationHub hub;
    private Context context;
    private String senderId;

    public Notifications(Context context, String senderId) {
        this.context = context;
        this.senderId = senderId;

        gcm = GoogleCloudMessaging.getInstance(context);
        hub = new NotificationHub("hub name", "connection string with listen access", context);
    }

    public void storeCategoriesAndSubscribe(Set<String> categories)
    {
        SharedPreferences settings = context.getSharedPreferences(PREFS_NAME, 0);
        settings.edit().putStringSet("categories", categories).commit();
        subscribeToCategories(categories);
    }

    public void subscribeToCategories(final Set<String> categories) {
        new AsyncTask<Object, Object, Object>() {
            @Override
            protected Object doInBackground(Object... params) {
                try {
                    String regid = gcm.register(senderId);
                    hub.register(regid, categories.toArray(new String[categories.size()]));
                } catch (Exception e) {
                    Log.e("MainActivity", "Failed to register - " + e.getMessage());
                    return e;
                }
                return null;
            }

            protected void onPostExecute(Object result) {
                String message = "Subscribed for categories: "
                        + categories.toString();
                Toast.makeText(context, message,
                        Toast.LENGTH_LONG).show();
            }
        }.execute(null, null, null);
    }

}
