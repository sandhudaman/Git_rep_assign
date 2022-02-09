/*I, Damanpreet Singh, 000741359 certify that this material is my original work. No
    other person's work has been used without due acknowledgement.
*/
/*Youtube Link:  https://youtu.be/eIdlC6jkSHQ
* */


package com.example.camohawksingh;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity
        implements AdapterView.OnItemSelectedListener {

    // using tags to log some events for debugging
    final static String tag = "----LIFECYCLE_OF ACTIVITY---- ";

    // used int to map position of spinner across all activity
    protected static int setPosition ;

    //used a string to what was the input in name Field
    protected static String setName ;

    //used a string to capture Current Activity used as
    //Text View when Switching Activity
    protected static String currentClass  = "From Activity One";



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Log.d(tag, "onCreate() of Activity One");


        // Set a selection before setting listener,
        // to prevent "ghost" selection on start
        Spinner mySpinner = findViewById(R.id.spinner);
        mySpinner.setSelection(0, true);
        mySpinner.setOnItemSelectedListener(this);



    }


    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {


        // log the spinner's choice used it for debugging
        Log.d(tag, String.valueOf(position));

        // global value of spinner was set so that next activity remembers what selection
        //was made for the spinner other wise it would default to position 0

        setPosition = position;

        // input method to catch Name Entered
        EditText myInput = findViewById(R.id.editTextTextPersonName);
        String  name = myInput.getText().toString();

        // IF-ELSE statement to set global value to empty if not changed
        // is changed it will set it to Name entered
        if (name.matches( "Enter Name")){
            setName = "";
        }
        else{setName = name;}



        //IF statements to switch to activity on spinner selection
        //I tried switch case it didn't work or you could say was buggy

        if (position == 0) {
            Log.d(tag, "Intiantiating class 1");
            nextActivity(view ,MainActivity.class);

        }
        if (position == 1){

            Log.d(tag, "Intiantiating class 2");
            nextActivity(view ,MainActivity2.class);


        }

        if (position == 2){
            Log.d(tag, "Intiantiating class 3");
            nextActivity(view ,MainActivity3.class);
            Log.d(tag, String.valueOf(position));
        }


    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

        // log the Nothing if nothing selected
        Log.d(tag, "Nothing Selected");

    }

    // Intent Method to switch Activity, Class c is used to select which class to switch to
    public void nextActivity(View view,Class  c) {

        Intent switch2Activity2 = new Intent(MainActivity.this,c);
        startActivity(switch2Activity2);
        



    }
}