package oauthfacebook.com.example.rafaelmiceli.applicationoauthfacebook;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.view.Menu;
import android.view.MenuItem;

import com.facebook.Session;
import com.facebook.SessionState;
import com.facebook.UiLifecycleHelper;


public class FacebookLogin extends FragmentActivity {

    private static final int SPLASH = 0;
    private static final int MAIN = 1;
    private static final int SETTINGS = 2;
    private static final int FRAGMENT_COUNT = SETTINGS + 1;


    private MenuItem settings;
    private boolean isResumed = false;
    private Fragment[] fragments = new Fragment[FRAGMENT_COUNT];
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

        uiHelper = new UiLifecycleHelper(this, callback);
        uiHelper.onCreate(savedInstanceState);

        setContentView(R.layout.activity_facebook_login);

        FragmentManager fm = getSupportFragmentManager();
        fragments[SPLASH] = fm.findFragmentById(R.id.splashFragment);
        fragments[MAIN] = fm.findFragmentById(R.id.mainFragment);
        fragments[SETTINGS] = fm.findFragmentById(R.id.userSettingsFragment);



        FragmentTransaction transaction = fm.beginTransaction();
        for(Fragment fragment : fragments) {
            if (fragment != null) {
                transaction.hide(fragment);
            }
        }

        transaction.commit();

    }

    private void onSessionStateChange(Session session, SessionState state, Exception exception) {
        // Only make changes if the activity is visible
        if (isResumed) {
            FragmentManager manager = getSupportFragmentManager();
            // Get the number of entries in the back stack
            int backStackSize = manager.getBackStackEntryCount();
            // Clear the back stack
            for (int i = 0; i < backStackSize; i++) {
                manager.popBackStack();
            }

            if (state.isOpened()) {
                // If the session state is open:
                // Show the authenticated fragment
                showFragment(MAIN, false);
            } else if (state.isClosed()) {
                // If the session state is closed:
                // Show the login fragment
                showFragment(SPLASH, false);
            }
        }
    }

    private void showFragment(int fragmentIndex, boolean addToBackStack) {

        FragmentManager fm = getSupportFragmentManager();
        FragmentTransaction transaction = fm.beginTransaction();
        for (int i = 0; i < fragments.length; i++) {
            if (i == fragmentIndex) {
                if (fragments[i] != null) {
                    transaction.show(fragments[i]);
                }
            } else {
                if (fragments[i] != null) {
                    transaction.hide(fragments[i]);
                }
            }
        }
        if (addToBackStack) {
            transaction.addToBackStack(null);
        }
        transaction.commit();
    }

    @Override
    public boolean onPrepareOptionsMenu(Menu menu) {
        // only add the menu when the selection fragment is showing
        if (fragments[MAIN].isVisible()) {
            if (menu.size() == 0) {
                settings = menu.add(R.string.settings);
            }
            return true;
        } else {
            menu.clear();
            settings = null;
        }
        return false;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (item.equals(settings)) {
            showFragment(SETTINGS, true);
            return true;
        }
        return false;
    }

    @Override
    protected void onResumeFragments() {
        super.onResumeFragments();
        Session session = Session.getActiveSession();

        if (session != null && session.isOpened()) {
            // if the session is already open,
            // try to show the selection fragment
            showFragment(MAIN, false);
        } else {
            // otherwise present the splash screen
            // and ask the person to login.
            showFragment(SPLASH, false);
        }
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        Session.getActiveSession().onActivityResult(this, requestCode, resultCode, data);
        uiHelper.onActivityResult(requestCode, resultCode, data);
    }

    @Override
    public void onResume() {
        super.onResume();
        uiHelper.onResume();
        isResumed = true;
    }

    @Override
    public void onPause() {
        super.onPause();
        uiHelper.onPause();
        isResumed = false;
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        uiHelper.onSaveInstanceState(outState);
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        uiHelper.onDestroy();
    }
}
