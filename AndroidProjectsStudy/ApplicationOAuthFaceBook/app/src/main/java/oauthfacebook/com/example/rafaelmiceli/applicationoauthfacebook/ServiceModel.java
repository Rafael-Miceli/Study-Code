package oauthfacebook.com.example.rafaelmiceli.applicationoauthfacebook;

import com.microsoft.azure.storage.table.TableServiceEntity;

/**
 * Created by Rafael on 20/11/2014.
 */
public class ServiceModel extends TableServiceEntity {

    private String mPrice;
    private int mTime;

    public ServiceModel(String login, String serviceType, String price, int time) {
        partitionKey = login;
        rowKey = serviceType;

        mPrice = price;
        mTime = time;
    }


    public String getPrice() {
        return mPrice;
    }

    public void setPrice(String Price) {
        mPrice = Price;
    }

    public int getTime() {
        return mTime;
    }

    public void setTime(int Time) {
        mTime = Time;
    }
}
