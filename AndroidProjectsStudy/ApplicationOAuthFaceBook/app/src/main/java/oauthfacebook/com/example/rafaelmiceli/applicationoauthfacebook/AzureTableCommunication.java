package oauthfacebook.com.example.rafaelmiceli.applicationoauthfacebook;

import com.microsoft.azure.storage.*;
import com.microsoft.azure.storage.table.*;
import com.microsoft.azure.storage.table.TableQuery.*;

/**
 * Created by Rafael on 19/11/2014.
 */
public class AzureTableCommunication {

    // Define the connection-string with your values.
    public static final String storageConnectionString =
            "DefaultEndpointsProtocol=http;" +
                    "AccountName=your_storage_account;" +
                    "AccountKey=your_storage_account_key";

    public final String TABLENAME = "services";


    public void createServiceTable() {
        try
        {
            // Retrieve storage account from connection-string.
            CloudStorageAccount storageAccount =
                    CloudStorageAccount.parse(storageConnectionString);

            // Create the table client.
            CloudTableClient tableClient = storageAccount.createCloudTableClient();

            // Create the table if it doesn't exist.
            String tableName = TABLENAME;
            CloudTable cloudTable = new CloudTable(tableName,tableClient);
            cloudTable.createIfNotExists();
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
