package oauthfacebook.com.example.rafaelmiceli.applicationoauthfacebook;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

/**
 * Created by Rafael on 16/11/2014.
 */
public class ServiceFragment extends Fragment {

    public final static String SERVICE_TITLE = "service title";
    public final static String TOP_CARD = "top card";

    String mServiceTitle;
    int mTopCardResourceId;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View theView = inflater.inflate(R.layout.fragment_services, container, false);

        Bundle arguments = getArguments();
        if (arguments != null) {
            mServiceTitle = arguments.getString(SERVICE_TITLE);
            mTopCardResourceId = arguments.getInt(TOP_CARD);

            displayValues(theView, mServiceTitle, mTopCardResourceId);
        }

        return theView;
    }

    private void displayValues(View theView, String serviceTitle, int topCardResourceId) {
        TextView serviceTitleTextView = (TextView) theView.findViewById(R.id.serviceTitle);
        ImageView topCardImageView = (ImageView) theView.findViewById(R.id.topCard);

        serviceTitleTextView.setText(serviceTitle);

        topCardImageView.setImageResource(topCardResourceId);
    }

    /*private void showActionActivity(int courseActionResourceId) {
        Intent intent = new Intent(getActivity(), CourseActionsActivity.class);
        intent.putExtra(CourseActionsActivity.COURSE_ACTION, getString(courseActionResourceId));
        intent.putExtra(CourseActionsActivity.COURSE_TITLE, mServiceTitle);
        intent.putExtra(CourseActionsActivity.TOP_CARD, mTopCardResourceId);

        startActivity(intent);
    }*/

}
