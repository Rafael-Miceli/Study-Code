package oauthfacebook.com.example.rafaelmiceli.applicationoauthfacebook;


import com.microsoft.azure.storage.CloudStorageAccount;
import com.microsoft.azure.storage.table.CloudTable;
import com.microsoft.azure.storage.table.CloudTableClient;
import com.microsoft.azure.storage.table.TableOperation;

/**
 * Created by Rafael on 19/11/2014.
 */
public class AzureTableCommunication {

    // Define the connection-string with your values.
    public static final String storageConnectionString =
            "DefaultEndpointsProtocol=https;" +
                    "AccountName=manicureapp;" +
                    "AccountKey=H35FsL0SaVu6uYedFAocWiN+gCr4vuQhq9TqWjqGmjsimZ3FNA0kCmlQf58ng3P8VE7iAakZqzueotX38uqupw==";

    public final String TABLENAME = "services";


    public void createServiceTable() {
        try
        {
            // Retrieve storage account from connection-string.
            CloudStorageAccount storageAccount = CloudStorageAccount.parse(storageConnectionString);

            // Create the table client.
            CloudTableClient tableClient = storageAccount.createCloudTableClient();

            CloudTable cloudTable = tableClient.getTableReference(TABLENAME);

            // Create the table if it doesn't exist.
            cloudTable.create();
        }
        catch (Exception e)
        {
            // Output the stack trace.
            e.printStackTrace();
        }
    }

    public void insertService(ServiceModel serviceModel) {
        try
        {
            // Retrieve storage account from connection-string.
            CloudStorageAccount storageAccount =
                    CloudStorageAccount.parse(storageConnectionString);

            // Create the table services.
            CloudTableClient tableClient = storageAccount.createCloudTableClient();

            // Create a cloud table object for the table.
            CloudTable cloudTable = tableClient.getTableReference(TABLENAME);


            // Create an operation to add the new service to the services table.
            TableOperation insertCustomer1 = TableOperation.insertOrReplace(serviceModel);

            // Submit the operation to the table service.
            cloudTable.execute(insertCustomer1);
        }
        catch (Exception e)
        {
            // Output the stack trace.
            e.printStackTrace();
        }
    }

}
