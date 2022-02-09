package com.example.camohawksingh;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Spinner;
import android.widget.TextView;


// changed it from default Inheritance to inherit Main Activity
public class MainActivity3 extends MainActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main3);
        Log.d(tag, "onCreate() of Activity Three");

        //This output is used to to Display Name, will display nothing if empty
        TextView myOutput = findViewById(R.id.textView3);
        myOutput.setText( setName );

        //using this output to display from what Activity teh switch was made for eg.From Activity2
        TextView myOutput3 = findViewById(R.id.textView2);
        myOutput3.setText( currentClass );

        // updating current class the user is in, after it was displayed as an output in this class
        currentClass = "From Activity Three";


        // setting spinner value to last selection made
        Spinner mySpinner2 = findViewById(R.id.spinner);
        mySpinner2.setSelection(MainActivity.setPosition, true);
        mySpinner2.setOnItemSelectedListener(this);




    }
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {


        // log the spinner's choice for debugging
        Log.d(tag, String.valueOf(position));

        //changing value of spinner selection to be use for next activity
        setPosition = position;

        //IF statements to switch activity on spinner selection
        if (position == 0) {
            Log.d(tag, "Intiantiating class 1");
            nextActivity(view ,MainActivity.class);
            currentClass  = "From Activity One";

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

    // Intent Method to switch Activity, Class c is used to select which class to switch to
    public void nextActivity(View view,Class  c) {

        Intent switch2Activity2 = new Intent(MainActivity3.this,c);
        startActivity(switch2Activity2);
    }




}