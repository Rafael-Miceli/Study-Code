package androidolderversion.com.example.rafael.myapplicationolderversion.model;

/**
 * Created by rafael.miceli on 09/10/2014.
 */
public class Subject {


    private int mid;
    private String mweight;
    private String mname;

    public Subject() {
    }

    public Subject(String name, String weight) {
        mname = name;
        mweight = weight;
    }

    public Subject(int id, String name, String weight) {
        mid = id;
        mname = name;
        mweight = weight;
    }

    public int getId() {
        return mid;
    }

    public void setId(int id) {
        mid = id;
    }

    public String getName() {
        return mname;
    }

    public void setName(String name) {
        mname = name;
    }

    public String getWeight() {
        return mweight;
    }

    public void setWeight(String weight) {
        mweight = weight;
    }
}
