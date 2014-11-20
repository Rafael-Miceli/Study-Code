package oauthfacebook.com.example.rafaelmiceli.applicationoauthfacebook;

import android.app.Application;

/**
 * Created by Rafael on 20/11/2014.
 */
public class AzureTableCommunicationApp extends Application {

    private AzureTableCommunication mAzureTableCommunication;

    public AzureTableCommunicationApp() {}

    public AzureTableCommunication getAzureTableCommunication() {
        if (mAzureTableCommunication == null) {
            mAzureTableCommunication = new AzureTableCommunication();
        }
        return mAzureTableCommunication;
    }
}
