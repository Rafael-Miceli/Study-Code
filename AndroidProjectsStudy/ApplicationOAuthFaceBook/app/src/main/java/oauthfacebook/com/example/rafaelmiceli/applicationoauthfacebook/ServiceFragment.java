package oauthfacebook.com.example.rafaelmiceli.applicationoauthfacebook;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

/**
 * Created by Rafael on 16/11/2014.
 */
public class ServiceFragment extends Fragment {

    public final static String SERVICE_TITLE = "service title";
    public final static String TOP_CARD = "top card";
    public final static String SERVICE_IDO = "service ido";
    public final static String SERVICE_PRICE = "service price";
    public final static String SERVICE_TIME = "service time";

    String mServiceTitle;
    int mTopCardResourceId;
    boolean mIdo;
    double mPrice;
    int mTime;

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
            mIdo = arguments.getBoolean(SERVICE_IDO);
            mPrice = arguments.getDouble(SERVICE_PRICE);
            mTime = arguments.getInt(SERVICE_TIME);

            displayValues(theView, mServiceTitle, mTopCardResourceId, mIdo, mPrice, mTime);
        }

        return theView;
    }

    private void displayValues(View theView, String serviceTitle, int topCardResourceId, boolean Ido, double price, int time) {
        TextView serviceTitleTextView = (TextView) theView.findViewById(R.id.serviceTitle);
        ImageView topCardImageView = (ImageView) theView.findViewById(R.id.topCard);
        CheckBox iDoServiceCheckBox = (CheckBox) theView.findViewById(R.id.checkBoxDoService);
        EditText priceEditText = (EditText) theView.findViewById(R.id.editTextPrice);
        EditText timeEditText = (EditText) theView.findViewById(R.id.editTextTime);



        serviceTitleTextView.setText(serviceTitle);
        topCardImageView.setImageResource(topCardResourceId);
        iDoServiceCheckBox.setChecked(Ido);

        priceEditText.setText(String.valueOf(price));
        timeEditText.setText(String.valueOf(time));
    }
}
