/*I, Damanpreet Singh, 000741359 certify that this material is my original work. No
        other person's work has been used without due acknowledgement.*/

// Video : https://youtu.be/JHEADYqNkvQ


package com.example.lab3;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity implements View.OnClickListener{

    // final variables to store string and file name for tag
    public final String SW_STATE = "SW_STATE";
    public final String SP_File = "shared_prefs.dat";
    public final String tag = "==MainActivity==";

    //this int variable will to used for the counter at button click
    public int counter ;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);



        // Fragments will be added  using  Get Fragment Manager
        FragmentManager fm = getSupportFragmentManager();

        // New Fragment Transaction
        FragmentTransaction fragmentTransaction = fm.beginTransaction();

        // Creating a new instance of both fragment classes Fragment class
        Fragment myFragment1 = new TopHalf();
        Fragment myFragment2 = new BottomHalf();


        // Using .replace to ensure that any previous fragment in the frame is detached.
        fragmentTransaction.replace(R.id.fragmentContainerView5, myFragment1);
        fragmentTransaction.replace(R.id.fragmentContainerView6, myFragment2);

        // Commiting fragements
        fragmentTransaction.commit();


    }

    //on click method for both buttons
    @Override
    public void onClick(View view) {

        Button bview = view.findViewById(R.id.button);
        bview.setOnClickListener(this::ButtonMinClicked);
        bview = bview.findViewById(R.id.button3);
        bview.setOnClickListener(this::ButtonMaxClicked);


    }

    //when - Button is clicked this method will be called
    public void ButtonMinClicked(View view) {
        TextView textView = findViewById(R.id.textView);
        counter--;
        Log.d(tag, "switchText " + counter );
        textView.setText(String.valueOf(counter));


    }

    //when - Button is clicked this method will be called
    public void ButtonMaxClicked(View view) {

        TextView textView = findViewById(R.id.textView);
        counter++;
        Log.d(tag, "switchText " + counter );
        textView.setText(String.valueOf(counter));


    }

    // on Pause method used to update sharedpreferences file usind Key named ID
    @Override
    public void onPause() {
        super.onPause();

        SharedPreferences sharedPreferences = getSharedPreferences(SP_File,
                MODE_PRIVATE);
        SharedPreferences.Editor editor = sharedPreferences.edit();
        int currentCount = counter;
        // using putInt method to store the integer value to key id
        editor.putInt("id",currentCount);
        editor.commit();
        Log.d(tag, "onPause() - saving state found "+ counter );
    }


    // onResume method used to fetch sharedpreferences file usind Key named ID
    @Override
    protected void onResume(){
        super.onResume();
        SharedPreferences sharedPreferences = getSharedPreferences(SP_File,
                MODE_PRIVATE);
        //get int method to get id value store default is 0

        int switchText = sharedPreferences.getInt("id", 0);
        counter = switchText;
        Log.d(tag, "onResume() - fetching state found " + switchText);
        //text view is updated with ID value
        TextView textView = findViewById(R.id.textView);
        textView.setText(String.valueOf(switchText));

    }

    // idon't think onStop or onDestroy method is required
    // realized this after making the video
    // on pause and resume should get the job done

}