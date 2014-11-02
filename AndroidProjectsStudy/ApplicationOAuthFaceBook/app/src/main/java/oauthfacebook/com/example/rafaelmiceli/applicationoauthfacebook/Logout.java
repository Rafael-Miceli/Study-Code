package oauthfacebook.com.example.rafaelmiceli.applicationoauthfacebook;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.view.Menu;
import android.view.MenuItem;

import com.facebook.Session;
import com.facebook.SessionState;
import com.facebook.UiLifecycleHelper;


public class Logout extends Activity {

    private UiLifecycleHelper uiHelper;
    private Session.StatusCallback callback =
            new Session.StatusCallback() {
                @Override
                public void call(Session session,
                                 SessionState state, Exception exception) {
                    onSessionStateChange(session, state, exception);
                }
            };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_logout);

        uiHelper = new UiLifecycleHelper(this, callback);
        uiHelper.onCreate(savedInstanceState);
    }

    private void onSessionStateChange(Session session, SessionState state, Exception exception) {
        // Only make changes if the activity is visible

        if (state.isOpened()) {
            // If the session state is open:
            // Show the authenticated fragment
            //showFragment(MAIN, false);
        } else if (state.isClosed()) {
            // If the session state is closed:
            // Show the login fragment
            Intent intent = new Intent(this, FacebookLogin.class);
            startActivity(intent);
        }

    }
}
