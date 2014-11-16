package oauthfacebook.com.example.rafaelmiceli.applicationoauthfacebook;


import android.content.Context;
import android.content.res.Resources;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

/**
 * Created by Rafael on 16/11/2014.
 */
public class ServicePageAdapter extends FragmentPagerAdapter {

    String[] mServiceTitles;
    Context mContext;

    public ServicePageAdapter(FragmentManager fm, Context context) {
        super(fm);

        mContext = context;
        Resources resources = mContext.getResources();
        mServiceTitles = resources.getStringArray(R.array.service_titles);
    }

    @Override
    public Fragment getItem(int i) {
        Bundle arguments = new Bundle();
        arguments.putString(ServiceFragment.SERVICE_TITLE, mServiceTitles[i]);
        arguments.putInt(ServiceFragment.TOP_CARD, translateTopCardIndex(i));


        ServiceFragment serviceFragment = new ServiceFragment();
        serviceFragment.setArguments(arguments);
        return serviceFragment;
    }

    private int translateTopCardIndex(int i) {
        int resourceId;

        switch (i) {
            case 0:
                resourceId = R.drawable.ps_android_logo;
                break;
            default:
                resourceId = R.drawable.ps_android_logo;
                break;
        }

        return resourceId;
    }

    @Override
    public CharSequence getPageTitle(int position) {
        return mServiceTitles[position];
    }

    @Override
    public int getCount() {
        return mServiceTitles.length;
    }
}
