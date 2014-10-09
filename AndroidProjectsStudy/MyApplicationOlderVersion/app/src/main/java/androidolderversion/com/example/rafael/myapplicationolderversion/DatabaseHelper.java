package androidolderversion.com.example.rafael.myapplicationolderversion;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.util.ArrayList;
import java.util.List;

import androidolderversion.com.example.rafael.myapplicationolderversion.model.Subject;

/**
 * Created by rafael.miceli on 09/10/2014.
 */
public class DatabaseHelper extends SQLiteOpenHelper {

    private static final int DATABASE_VERSION = 1;
    private static final String DATABASE_NAME = "grades";
    private static final String TABLE_SUBJECTS = "subjects";

    //Subjects columns names
    private static final String COLUMN_ID = "id";
    private static final String COLUMN_NAME = "name";
    private static final String COLUMN_WEIGHT = "weight";

    public DatabaseHelper(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        String CREATE_SUBJECTS_TABLE = "CREATE TABLE " + TABLE_SUBJECTS + "("
                + COLUMN_ID + " INTEGER PRIMARY KEY," + COLUMN_NAME + " TEXT,"
                + COLUMN_WEIGHT + " INTEGER" + ")";
        sqLiteDatabase.execSQL(CREATE_SUBJECTS_TABLE);
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int oldVersion, int newVersion) {

        sqLiteDatabase.execSQL("DROP TABLE IF EXISTS " + TABLE_SUBJECTS);

        onCreate(sqLiteDatabase);
    }

    void addSubject(Subject subject) {
        SQLiteDatabase sqLiteDatabase = this.getWritableDatabase();

        ContentValues values = new ContentValues();
        values.put(COLUMN_NAME, subject.getName());
        values.put(COLUMN_WEIGHT, subject.getWeight());

        sqLiteDatabase.insert(TABLE_SUBJECTS, null, values);
        sqLiteDatabase.close();
    }

    Subject getSubject(int id) {
        SQLiteDatabase sqLiteDatabase = this.getReadableDatabase();

        Cursor cursor = sqLiteDatabase.query(TABLE_SUBJECTS, new String[] {COLUMN_ID,
                        COLUMN_NAME, COLUMN_WEIGHT}, COLUMN_ID + "=?",
                new String[] { String.valueOf(id) }, null, null, null, null);
        if (cursor != null)
            cursor.moveToFirst();

        Subject subject = new Subject(Integer.parseInt(cursor.getString(0)),
                cursor.getString(1), cursor.getString(2));

        return subject;
    }


    public List<Subject> getAllSubjects() {
        List<Subject> SubjectList = new ArrayList<Subject>();

        String selectQuery = "SELECT  * FROM " + TABLE_SUBJECTS;

        SQLiteDatabase sqLiteDatabase = this.getWritableDatabase();
        Cursor cursor = sqLiteDatabase.rawQuery(selectQuery, null);


        if (cursor.moveToFirst()) {
            do {
                Subject Subject = new Subject();
                Subject.setId(Integer.parseInt(cursor.getString(0)));
                Subject.setName(cursor.getString(1));
                Subject.setWeight(cursor.getString(2));

                SubjectList.add(Subject);
            } while (cursor.moveToNext());
        }

        cursor.close();

        return SubjectList;
    }


    public int updateSubject(Subject Subject) {
        SQLiteDatabase sqLiteDatabase = this.getWritableDatabase();

        ContentValues values = new ContentValues();
        values.put(COLUMN_NAME, Subject.getName());
        values.put(COLUMN_WEIGHT, Subject.getWeight());

        return sqLiteDatabase.update(TABLE_SUBJECTS, values, COLUMN_ID + " = ?",
                new String[] { String.valueOf(Subject.getId()) });
    }


    public void deleteSubject(Subject Subject) {
        SQLiteDatabase sqLiteDatabase = this.getWritableDatabase();
        sqLiteDatabase.delete(TABLE_SUBJECTS, COLUMN_ID + " = ?",
                new String[] { String.valueOf(Subject.getId()) });
        sqLiteDatabase.close();
    }


    public int getSubjectsCount() {
        String countQuery = "SELECT  * FROM " + TABLE_SUBJECTS;
        SQLiteDatabase sqLiteDatabase = this.getReadableDatabase();
        Cursor cursor = sqLiteDatabase.rawQuery(countQuery, null);
        cursor.close();

        return cursor.getCount();
    }
}
